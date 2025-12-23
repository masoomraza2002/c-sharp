using System;
using System.Globalization;

using ItemAlias = LibraryItemSystem.Items;

namespace LibraryItemSystem
{
    public enum UserRole
    {
        Admin,
        Librarian,
        Member
    }

    public enum ItemStatus
    {
        Available,
        Borrowed,
        Reserved,
        Lost
    }

    public abstract class LibraryItem
    {
        public string Title { get; }
        public string Author { get; }
        public int ItemId { get; }

        public LibraryItem(string title, string author, int itemId)
        {
            Title = title;
            Author = author;
            ItemId = itemId;
        }

        public abstract void display();
        public abstract double calLateFee(int dayLate);
    }

    public interface IReverse
    {
        void reverse();
    }

    public interface INotifiaction
    {
        void notify(string mess);
    }


    namespace Items
    {
        public class Book : LibraryItem, IReverse, INotifiaction
        {
            public ItemStatus status { get; set; }

            public Book(string title, string author, int itemId) : base(title, author, itemId)
            {
                status = ItemStatus.Available;
            }
            public override void display()
            {
                Console.WriteLine($"book {Title};; author {Author};; ID {ItemId}");
            }
            public override double calLateFee(int late)
            {
                return late * 1.0;
            }

            void IReverse.reverse()
            {
                Console.WriteLine("Book Reversed");
            }

            void INotifiaction.notify(string mess)
            {
                Console.WriteLine($"your notification {mess}");
            }
        }

        public class Magzine : LibraryItem
        {
            public ItemStatus status { get; set; }

            public Magzine(string title, string author, int itemId) : base(title, author, itemId)
            {
                status = ItemStatus.Available;
            }
            public override void display()
            {
                Console.WriteLine($"book {Title};; author {Author};; ID {ItemId}");
            }
            public override double calLateFee(int day)
            {
                return 0.5 + day;
            }
        }
    }

    namespace Users
    {
        public class Member
        {
            public string Name { get; set; }
            public UserRole Role { get; set; }

            public Member(string name)
            {
                Name = name;
                Role = UserRole.Member;
            }
        }
    }

    public static partial class LibraryAnalytics
    {
        public static int TotalBorrow { get; set; }
    }

    public static partial class LibraryAnalytics
    {
        public static void DisplayAnalytics()
        {
            Console.WriteLine($"total borwwoed {TotalBorrow}");
        }
    }

    class Obj
    {

        public static void obj()
        {
            ItemAlias.Book book = new ItemAlias.Book("Fire of wings", "Dr. APJ Kalam", 101);
            ItemAlias.Magzine magzine = new ItemAlias.Magzine("3 idiot", "Chetan bhagat", 102);
            
            Console.WriteLine(book.calLateFee(3));
            Console.WriteLine(magzine.calLateFee(3));

            IReverse reserve =  book;
            INotifiaction notifyy= book;

            reserve.reverse();
            notifyy.notify("your book ready");

            List<LibraryItem> itms = new List<LibraryItem>
            {
                book,magzine
            };

            foreach(LibraryItem itm in itms)
            {
                itm.display();
            }

            Console.WriteLine("method selection at run time");

            LibraryAnalytics.TotalBorrow++;
            LibraryAnalytics.DisplayAnalytics();

            Users.Member member = new Users.Member("masoom");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Role: {book.status}");
        }
    }
}