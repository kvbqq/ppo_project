using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibrarySystem
{
    // Klasa odpowiedzialna za trwałe przechowywanie danych książek
    public class LibraryStorage
    {
        private const string BooksFile = "books.csv"; // Plik przechowujący dane książek

        // Ładowanie książek z pliku CSV
        public List<Book> LoadBooks()
        {
            if (!File.Exists(BooksFile))
                return new List<Book>();

            return File.ReadAllLines(BooksFile)
                .Select(Book.FromCsv)
                .ToList();
        }

        // Zapisywanie listy książek do pliku CSV
        public void SaveBooks(List<Book> books)
        {
            File.WriteAllLines(BooksFile, books.Select(b => b.ToString()));
        }
    }

}
