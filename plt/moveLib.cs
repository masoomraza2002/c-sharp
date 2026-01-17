using System;
using System.Collections.Generic;
 
public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(Film film);
    void RemoveFilm(string title);
    List<Film> GetFilms();
    List<Film> SearchFilms(string query);
    int GetTotalFilmCount();
}
 
public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
} 

public class FilmLibrary : IFilmLibrary
{
    private List<Film> _films = new List<Film>();

    public void AddFilm(Film film)
    {
        _films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        for (int i = 0; i < _films.Count; i++)
        {
            if (string.Equals(_films[i].Title, title, StringComparison.OrdinalIgnoreCase))
            {
                _films.RemoveAt(i);
                break;
            }
        }
    }

    public List<Film> GetFilms()
    {
        return _films;
    }

    public List<Film> SearchFilms(string query)
    {
        List<Film> result = new List<Film>();

        for (int i = 0; i < _films.Count; i++)
        {
            if (_films[i].Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                _films[i].Director.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                result.Add(_films[i]);
            }
        }

        return result;
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
} 

class FilmA
{
    public static void film()
    {
        FilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));

        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());

        Console.WriteLine("\nSearch Results:");
        foreach (var film in library.SearchFilms("Nolan"))
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        library.RemoveFilm("Inception");
        Console.WriteLine("\nAfter Removal:");
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
    }
}
