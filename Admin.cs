using System;

namespace LibrarySystem
{  
    // Klasa reprezentująca administratora systemu bibliotecznego
    public class Admin : User
    {
        public override void AccessLibrary(Library library)
        {
            while (true)
            {
                Console.WriteLine("\nOpcje Administratora:");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Dodaj książkę\n2. Modyfikuj książkę\n3. Usuń książkę\n4. Wyświetl książki\n5. Wyjdź");
                Console.WriteLine("========================================\n");

                Console.Write("Wybierz opcję: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Podaj tytuł: ");
                            var title = Console.ReadLine();
                            Console.Write("Podaj autora: ");
                            var author = Console.ReadLine();
                            library.AddBook(title, author);
                            break;

                        case "2":
                            Console.Write("Podaj ID książki do modyfikacji: ");
                            var id = int.Parse(Console.ReadLine());
                            Console.Write("Podaj nowy tytuł: ");
                            var newTitle = Console.ReadLine();
                            Console.Write("Podaj nowego autora: ");
                            var newAuthor = Console.ReadLine();
                            library.ModifyBook(id, newTitle, newAuthor);
                            break;

                        case "3":
                            Console.Write("Podaj ID książki do usunięcia: ");
                            id = int.Parse(Console.ReadLine());
                            library.RemoveBook(id);
                            break;

                        case "4":
                            library.ListBooks();
                            break;

                        case "5":
                            Console.WriteLine("\nDo widzenia, Administratorze!");
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