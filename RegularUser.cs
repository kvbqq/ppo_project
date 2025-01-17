using System;

namespace LibrarySystem
{         
    // Klasa reprezentująca zwykłego użytkownika systemu bibliotecznego
    public class RegularUser : User
    {
        public override void AccessLibrary(Library library)
        {
            while (true)
            {
                Console.WriteLine("\nOpcje Użytkownika:");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Wypożycz książkę\n2. Zwróć książkę\n3. Wyświetl książki\n4. Wyjdź");
                Console.WriteLine("========================================\n");

                Console.Write("Wybierz opcję: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Podaj ID książki do wypożyczenia: ");
                            var id = int.Parse(Console.ReadLine());
                            library.BorrowBook(id);
                            break;

                        case "2":
                            Console.Write("Podaj ID książki do zwrotu: ");
                            id = int.Parse(Console.ReadLine());
                            library.ReturnBook(id);
                            break;

                        case "3":
                            library.ListBooks();
                            break;

                        case "4":
                            Console.WriteLine("\nDo widzenia, Użytkowniku!");
                            return;

                        default:
                            Console.WriteLine("\nNieprawidłowa opcja. Spróbuj ponownie.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nBłąd: {ex.Message}");
                }
            }
        }
    }
}