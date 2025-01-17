using System;

namespace LibrarySystem
{
    // Klasa odpowiedzialna za przechowywanie informacji o książkach
    public class Book
    {
        public int Id { get; private set; } // Unikalny identyfikator książki
        public string Title { get; private set; } // Tytuł książki
        public string Author { get; private set; } // Autor książki
        public bool IsBorrowed { get; private set; } // Status wypożyczenia książki

        // Konstruktor tworzący nową książkę
        public Book(int id, string title, string author, bool isBorrowed)
        {
            Id = id;
            Title = title;
            Author = author;
            IsBorrowed = isBorrowed;
        }

        // Metoda oznaczająca książkę jako wypożyczoną
        public void Borrow()
        {
            if (IsBorrowed)
                throw new InvalidOperationException("Książka jest już wypożyczona.");

            IsBorrowed = true;
        }

        // Metoda oznaczająca książkę jako zwróconą
        public void Return()
        {
            if (!IsBorrowed)
                throw new InvalidOperationException("Książka nie jest wypożyczona.");

            IsBorrowed = false;
        }

        // Konwersja szczegółów książki do formatu CSV
        public override string ToString()
        {
            return $"{Id},{Title},{Author},{IsBorrowed}";
        }

        // Tworzenie instancji książki na podstawie linii CSV
        public static Book FromCsv(string csvLine)
        {
            var parts = csvLine.Split(',');
            return new Book(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                bool.Parse(parts[3])
            );
        }
    }
}