using System;

namespace LibrarySystem
{
    // Klasa odpowiedzialna za uruchamianie aplikacji
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new LibraryStorage();
            var library = new Library(storage);

            Console.WriteLine("\nWitamy w systemie bibliotecznym!");
            Console.WriteLine("========================================");
            Console.WriteLine("Jesteś Administratorem czy Użytkownikiem? (Wpisz 'Administrator' lub 'Użytkownik'):");
            var role = Console.ReadLine();

            User user;
            if (role.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            {
                user = new Admin();
            }
            else if (role.Equals("Użytkownik", StringComparison.OrdinalIgnoreCase))
            {
                user = new RegularUser();
            }
            else
            {
                Console.WriteLine("\nNieprawidłowa rola. Zakończenie programu.");
                return;
            }

            user.AccessLibrary(library);
        }
    }
}