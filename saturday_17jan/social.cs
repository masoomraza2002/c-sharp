using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Json;

namespace MiniSocialMedia
{            
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }
            
    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }
            
    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }
    }
            
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following =
            new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Invalid username", nameof(username));

            if (!Regex.IsMatch(email ?? "", @"^[^@]+@[^@]+\.[^@]+$"))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLower();
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
        }

        public bool IsFollowing(string username)
            => _following.Contains(username);

        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            var post = new Post(this, content.Trim());
            _posts.Add(post);

            OnNewPost?.Invoke(post);
        }

        public IReadOnlyList<Post> GetPosts()
            => _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other == null) return 1;

            return string.Compare(
                Username,
                other.Username,
                StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
            => $"@{Username}";
    }
            
    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }
            
    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();

        public T? Find(Predicate<T> match)
            => _items.Find(match);
    }
            
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime time)
        {
            var diff = DateTime.UtcNow - time;

            if (diff.TotalSeconds < 60)
                return "just now";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} h ago";

            return time.ToString("MMM dd");
        }
    }
            
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            return user.GetType()
                       .GetField("_following",
                           System.Reflection.BindingFlags.NonPublic |
                           System.Reflection.BindingFlags.Instance)!
                       .GetValue(user) as IEnumerable<string>
                   ?? Enumerable.Empty<string>();
        }
    }
            
    public class Social
    {
        private static readonly Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";

        public static void social()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite($"Error: {ex.Message}", ConsoleColor.Red);
                    if (ex.InnerException != null)
                        Console.WriteLine(" → " + ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error occurred.");
                    Console.WriteLine(ex);
                    LogError(ex);
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "3": SaveData(); Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (_users.Find(u => u.Username.Equals(username,
                StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            var user = new User(username!, email!);
            _users.Add(user);

            Console.WriteLine("User registered successfully");
        }

        static void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            var user = _users.Find(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;

            user.OnNewPost += post =>
            {
                if (_currentUser!.IsFollowing(post.Author.Username))
                    Console.WriteLine($"\n New post from {post.Author}");
            };

            Console.WriteLine("Login successful");
        }
        
        static void ShowMainMenu()
        {
            Console.WriteLine($"Logged in as {_currentUser}");
            Console.WriteLine(
                "1.Post  2.My Posts  3.Timeline  4.Follow  5.Users  6.Logout  7.Exit");

            Console.Write("Choice: ");
            switch (Console.ReadLine())
            {
                case "1": PostMessage(); break;
                case "2": ShowPosts(_currentUser!.GetPosts()); break;
                case "3": ShowTimeline(); break;
                case "4": FollowUser(); break;
                case "5": ListUsers(); break;
                case "6": _currentUser = null; break;
                case "7": SaveData(); Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }

        static void PostMessage()
        {
            Console.Write("Post: ");
            var content = Console.ReadLine();
            _currentUser!.AddPost(content!);
            Console.WriteLine("Post added");
        }

        static void ShowTimeline()
        {
            var posts = new List<Post>();

            posts.AddRange(_currentUser!.GetPosts());

            foreach (var user in _users.GetAll())
                if (_currentUser.IsFollowing(user.Username))
                    posts.AddRange(user.GetPosts());

            foreach (var post in posts.OrderByDescending(p => p.CreatedAt))
            {
                Console.WriteLine(post);
                Console.WriteLine($"({post.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine("--------------------------------");
            }
        }

        static void ShowPosts(IEnumerable<Post> posts)
        {
            if (!posts.Any())
            {
                Console.WriteLine("No posts");
                return;
            }

            foreach (var post in posts)
            {
                Console.WriteLine(post);
                Console.WriteLine($"({post.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine("--------------------------------");
            }
        }

        static void FollowUser()
        {
            Console.Write("Follow username: ");
            var name = Console.ReadLine();

            if (_users.Find(u => u.Username.Equals(name,
                StringComparison.OrdinalIgnoreCase)) == null)
                throw new SocialException("User does not exist");

            _currentUser!.Follow(name!);
            Console.WriteLine("Now following " + name);
        }

        static void ListUsers()
        {
            foreach (var user in _users.GetAll().OrderBy(u => u))
                Console.WriteLine(user.GetDisplayName());
        }
        
        static void SaveData()
        {
            try
            {
                var json = JsonSerializer.Serialize(_users.GetAll());
                File.WriteAllText(_dataFile, json);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LoadData()
        {
            if (!File.Exists(_dataFile)) return;

            try
            {
                var json = File.ReadAllText(_dataFile);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                if (users != null)
                    users.ForEach(u => _users.Add(u));
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LogError(Exception ex)
        {
            File.AppendAllText("error.log",
                $"{DateTime.Now}\n{ex}\n-----------------\n");
        }

        static void ConsoleColorWrite(string msg, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = old;
        }
        
    }
}
