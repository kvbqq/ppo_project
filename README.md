# System Biblioteczny

## Opis Projektu

System biblioteczny to aplikacja konsolowa, która umożliwia zarządzanie książkami w bibliotece. Program wykorzystuje programowanie obiektowe do modelowania książek, użytkowników oraz operacji bibliotecznych. Dane książek są przechowywane w pliku CSV, co zapewnia trwałość danych między uruchomieniami aplikacji.

---

## Kluczowe Filary Programowania Obiektowego

### 1. **Abstrakcja**

- Program wykorzystuje abstrakcję do modelowania użytkowników za pomocą klasy abstrakcyjnej `User`. Dzięki temu można zdefiniować wspólne operacje dla różnych typów użytkowników (np. administrator i użytkownik regularny), jednocześnie umożliwiając różną implementację tych operacji w klasach pochodnych (`Admin`, `RegularUser`).

### 2. **Hermetyzacja**

- Dane w klasach są ukryte poprzez stosowanie modyfikatorów dostępu (`private`, `protected`) oraz odpowiednich metod dostępowych (`get`, `set`). Na przykład, właściwości klasy `Book` (np. `Id`, `Title`, `Author`, `IsBorrowed`) są tylko do odczytu na zewnątrz klasy, co zapewnia kontrolę nad ich zmianą.

### 3. **Dziedziczenie**

- Klasa `User` jest bazą dla klas `Admin` i `RegularUser`, co umożliwia ponowne użycie kodu i rozszerzanie funkcjonalności. Dzięki temu klasy pochodne mogą implementować specyficzne dla nich funkcje, jak np. dodawanie książek przez administratora.

### 4. **Polimorfizm**

- Program wykorzystuje polimorfizm do obsługi różnych typów użytkowników. Przykładowo, metoda `AccessLibrary` w klasie `User` jest implementowana inaczej w klasach `Admin` i `RegularUser`, co pozwala na zróżnicowanie operacji dostępnych dla tych użytkowników.

---

## Funkcjonalności

### Opcje Administratora:

1. Dodanie nowej książki.
2. Modyfikacja istniejącej książki.
3. Usunięcie książki.
4. Wyświetlenie listy książek.
5. Wyjście z programu.

### Opcje Użytkownika:

1. Wypożyczenie książki.
2. Zwrot książki.
3. Wyświetlenie listy książek.
4. Wyjście z programu.

---

## Struktura Kodu

- **`Book`**: Reprezentuje książkę, przechowując jej dane oraz umożliwiając operacje takie jak wypożyczenie i zwrot.
- **`Library`**: Zarządza operacjami na książkach, takimi jak dodawanie, modyfikowanie, usuwanie, wypożyczanie i zwracanie.
- **`LibraryStorage`**: Obsługuje trwałe przechowywanie książek w pliku CSV.
- **`User`**: Klasa abstrakcyjna definiująca interfejs użytkowników systemu.
  - **`Admin`**: Rozszerza `User`, dodając funkcje administracyjne (np. zarządzanie książkami).
  - **`RegularUser`**: Rozszerza `User`, umożliwiając podstawowe operacje na książkach (wypożyczanie, zwracanie).
- **`Program`**: Punkt wejścia do aplikacji, obsługuje logikę wyboru ról użytkownika i inicjalizuje obiekty systemu.

---

## Możliwości Rozwoju

1. **Interfejs Graficzny**

   - Dodanie graficznego interfejsu użytkownika (GUI), np. w technologii Windows Forms lub WPF, aby uczynić aplikację bardziej intuicyjną.

2. **Obsługa Wielu Użytkowników**

   - Implementacja logowania użytkowników z wykorzystaniem loginu i hasła.
   - Przechowywanie informacji o użytkownikach w bazie danych lub pliku.

3. **Zaawansowana Przechowalnia Danych**

   - Zastąpienie pliku CSV bazą danych, np. SQLite lub SQL Server, w celu bardziej wydajnego zarządzania danymi.

4. **Historia Wypożyczeń**
   - Rozbudowa systemu o moduł śledzenia historii wypożyczeń (kto i kiedy wypożyczył książkę).

---

## Instrukcja Uruchomienia

1. Sklonuj repozytorium lub skopiuj pliki projektu.
2. Upewnij się, że na Twoim systemie jest zainstalowane środowisko .NET.
3. W folderze projektu uruchom następujące polecenie:
   ```
   dotnet run
   ```
4. Postępuj zgodnie z instrukcjami wyświetlanymi w konsoli.
