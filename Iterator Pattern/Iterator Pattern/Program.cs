using System;
using System.Collections;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; } 
    public string Author { get; set; } 
    public int Year { get; set; } 

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} автор {Author}, {Year}"; 
    }
}


public class LibraryIterator : IEnumerator<Book>
{
    private readonly Book[] _books; 
    private int _position = -1;

    public LibraryIterator(Book[] books)
    {
        _books = books;
    }

    public Book Current => _books[_position]; 

    object IEnumerator.Current => Current; 

    public bool MoveNext()
    {
        _position++;
        return _position < _books.Length; 
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Dispose()
    {

    }
}

public class Library : IEnumerable<Book>
{
    private Book[] _books = new Book[0]; 

    public void AddBook(Book book)
    {
        Array.Resize(ref _books, _books.Length + 1); 
        _books[^1] = book;
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(_books); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); 
    }
}

public class Program
{
    public static void Main()
    {
        Library library = new Library();
        
        library.AddBook(new Book("1984", "Джордж Оруэлл", 1949)); 
        library.AddBook(new Book("Убить пересмешника", "Харпер Ли", 1960));
        library.AddBook(new Book("Великий Гэтсби", "Ф. Скотт Фицджеральд", 1925));

        Console.WriteLine("Книги в библиотеке:");
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}
