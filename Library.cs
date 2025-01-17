using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    // Klasa odpowiedzialna za zarządzanie operacjami biblioteki
    public class Library
    {
        private List<Book> books; // Lista książek w bibliotece
        private LibraryStorage storage; // Obiekt do obsługi trwałego przechowywania książek

        // Konstruktor inicjalizujący bibliotekę i ładowanie książek
        public Library(LibraryStorage storage)
        {
            this.storage = storage;
            books = storage.LoadBooks(); // Ładowanie książek z pamięci
        }

        // Dodawanie nowej książki do biblioteki
        public void AddBook(string title, string author)
        {
            var newId = books.Any() ? books.Max(b => b.Id) + 1 : 1; // Generowanie nowego ID
            books.Add(new Book(newId, title, author, false));
            storage.SaveBooks(books); // Zapisywanie zaktualizowanej listy książek
            Console.WriteLine("\nKsiążka została dodana pomyślnie!");
        }

        // Modyfikowanie danych istniejącej książki
        public void ModifyBook(int id, string newTitle, string newAuthor)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Nie znaleziono książki.");

            books.Remove(book); // Usuwanie starej wersji książki
            books.Add(new Book(id, newTitle, newAuthor, book.IsBorrowed)); // Dodawanie zaktualizowanej wersji
            storage.SaveBooks(books);
            Console.WriteLine("\nKsiążka została zmodyfikowana pomyślnie!");
        }

        // Usuwanie książki z biblioteki
        public void RemoveBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Nie znaleziono książki.");

            books.Remove(book);
            storage.SaveBooks(books);
            Console.WriteLine("\nKsiążka została usunięta pomyślnie!");
        }

        // Oznaczanie książki jako wypożyczonej
        public void BorrowBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Nie znaleziono książki.");

            book.Borrow();
            storage.SaveBooks(books);
            Console.WriteLine("\nKsiążka została wypożyczona pomyślnie!");
        }

        // Oznaczanie książki jako zwróconej
        public void ReturnBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Nie znaleziono książki.");

            book.Return();
            storage.SaveBooks(books);
            Console.WriteLine("\nKsiążka została zwrócona pomyślnie!");
        }

        // Wyświetlanie listy wszystkich książek w bibliotece
        public void ListBooks()
        {
            if (!books.Any())
            {
                Console.WriteLine("\nBrak dostępnych książek w bibliotece.");
                return;
            }

            Console.WriteLine("\nDostępne książki:");
            Console.WriteLine("========================================");
            Console.WriteLine("ID  | Tytuł                        | Autor                | Status");
            Console.WriteLine("========================================");

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id,-3} | {book.Title,-28} | {book.Author,-20} | {(book.IsBorrowed ? "Wypożyczona" : "Dostępna")}");
            }
            Console.WriteLine("========================================\n");
        }
    }
}