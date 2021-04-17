using System;

namespace ClassesDll
{
    public class Functions
    {
        public static string ReadStringFromConsole(string text)
        {
            string result = "";

            while (string.IsNullOrEmpty(result))
            {
                Console.Write(text + ": ");
                result = Console.ReadLine()!;
            }

            return result;
        }


        public static int ReadNumFromConsole(string text)
        {
            Console.Write(text + ": ");

            try
            {
                string lineFromUser = Console.ReadLine()!;

                if (string.IsNullOrEmpty(lineFromUser))
                {
                    throw new FormatException();
                }

                return int.Parse(lineFromUser);
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели не число");

                return ReadNumFromConsole(text);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели неправильное значение");

                return ReadNumFromConsole(text);
            }
        }

        public static int ReadNumFromConsoleMinMax(int min, int max)
        {
            Console.Write("Введите цифру " + min + "-" + max + ": ");

            int result;
            try
            {
                string lineFromUser = Console.ReadLine()!;

                if (string.IsNullOrEmpty(lineFromUser))
                {
                    throw new FormatException();
                }

                result = int.Parse(lineFromUser);

                if (result < min || result > max)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неправильное значение, попробуйте еще раз");
                return ReadNumFromConsoleMinMax(min, max);
            }

            return result;
        }

        public static void ListOfBooks(ILibrary library, bool showMainMenuItem = true)
        {
            Console.WriteLine();
            Console.WriteLine("Список книг:");
            Console.WriteLine();
            // этот цикл for нужен, чтобы вывести список книг
            // длина массива - это кол-во книг
            for (int indexOfBook = 0; indexOfBook < library.Count(); indexOfBook++)
            {
                Book book = library.GetBookByIndex(indexOfBook);

                int bookNumber = indexOfBook + 1;
                ShowBookString(bookNumber, book);
            }

            Console.WriteLine("");

            if (showMainMenuItem)
            {
                Console.WriteLine("0. Для возврата в главное меню");
                Console.WriteLine("");
            }
        }

        public static int ChooseType()
        {
            Console.WriteLine();
            Console.WriteLine("Виды изданий:");
            Console.WriteLine();
            Console.WriteLine("1. Книга");
            Console.WriteLine("2. Газета");
            Console.WriteLine("3. Журнал");
            Console.WriteLine();

            return ReadNumFromConsoleMinMax(1, 3);
        }

        public static void ShowBookString(int bookNumber, Book book)
        {
            Console.WriteLine(GetBookString(bookNumber, book));
        }
        public static string GetBookString(int bookNumber, Book book)
        {
            string type;

            if (book.Type.Equals(Book.TYPE.Book))
            {
                type = "Книга";
            }
            else if (book.Type.Equals(Book.TYPE.Magazine))
            {
                type = "Журнал";
            }
            else if (book.Type.Equals(Book.TYPE.Newspaper))
            {
                type = "Газета";
            }
            else
            {
                throw new Exception("Неизвестный вид издания");
            }

            string searchResult = bookNumber + ". " + book.Name + " (" + type + ", " + book.Author1 + ", ";

            if (book.Author2.Length > 0)
            {
                searchResult += book.Author2 + ", ";
            }

            if (book.Author3.Length > 0)
            {
                searchResult += book.Author3 + ", ";
            }

            return
                searchResult
                + book.Year + ", "
                + book.PagesCount
                + " стр., изд. " + book.Publisher
                + ", г. " + book.City + ")";
        }

        public static void PressAnyKey()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static void AddDummyBooks(LibraryBase library)
        {
            Book book1 = new Book(
                "Ромашка", // название
                Book.TYPE.Book, // тип издания
                "Москва", // место издания
                "Питер", // название издательства
                1995, // год издания
                105, // кол-во страниц
                "Иванов В. В." // автор 1
            );

            library.Add(book1);

            Book book2 = new Book(
                "Богомол", // название
                Book.TYPE.Book, // тип издания
                "Москва", // место издания
                "Питер", // название издательства
                2005, // год издания
                55, // кол-во страниц
                "Петров А. А." // автор 1
            );

            library.Add(book2);

            Book book3 = new Book(
                "Компьютер для начинающих", // название
                Book.TYPE.Book, // тип издания
                "Севастополь", // место издания
                "Крым", // название издательства
                2014, // год издания
                105, // кол-во страниц
                "Сидоров И. К." // автор 1
            );

            library.Add(book3);

            Book book4 = new Book(
                "Модница", // название
                Book.TYPE.Newspaper, // тип издания
                "Москва", // место издания
                "ЮТФ", // название издательства
                2020, // год издания
                30, // кол-во страниц
                "Васькин Е. О.", // автор 1
                "Сидоров И. К."
            );

            library.Add(book4);

            Book book5 = new Book(
                "Комсомолец", // название
                Book.TYPE.Magazine, // тип издания
                "Краснодар", // место издания
                "ЮТФ", // название издательства
                1995, // год издания
                15, // кол-во страниц
                "Иванов В. В.", // автор 1
                "Петров А. А.",
                "Сидоров И. К."
            );

            library.Add(book5);
        }

        public static Book.TYPE IntToType(int type)
        {
            return type == 1 ? Book.TYPE.Book : (type == 2 ? Book.TYPE.Newspaper : Book.TYPE.Magazine);
        }

        public static int TypeToInt(Book.TYPE type)
        {
            return type.Equals(Book.TYPE.Book) ? 1 : (type.Equals(Book.TYPE.Newspaper) ? 2 : 3);
        }
    }
}