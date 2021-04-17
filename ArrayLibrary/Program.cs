using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ClassesDll;

namespace ArrayLibrary
{
    public class Program
    {
        protected static void Main(string[] args)
        {
            Console.Title = "«Электронная библиотека» версия 1.0, разработала Жигалова О.А., студентка группы ИСП 19-1";

            LibraryBase library = new ArrayLibrary();
            Functions.AddDummyBooks(library);
            MainMenu(library);
        }

        protected static void MainMenu(LibraryBase library)
        {
            string[] type = library.GetType().ToString().Split(".");

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Добро пожаловать в " + type[1]);
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine();
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Редактировать книгу");
            Console.WriteLine("3. Удалить книгу");
            Console.WriteLine("4. Поиск книги");
            Console.WriteLine("5. Вывести весь список книг");
            Console.WriteLine();

            int action = Functions.ReadNumFromConsoleMinMax(1, 5);
            Console.Clear();

            if (action == 1)
            {
                AddBook(library);
            }
            else if (action == 2)
            {
                ChooseBookToEdit(library);
            }
            else if (action == 3)
            {
                DeleteBook(library);
            }
            else if (action == 4)
            {
                FindBook(library);
            }
            else if (action == 5)
            {
                Functions.ListOfBooks(library, false);
                Functions.PressAnyKey();
                MainMenu(library);
            }
        }

        private static void FindBook(LibraryBase library)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Выберите поле, по которому хотите искать:");
            Console.WriteLine();
            Console.WriteLine("1. Название книги");
            Console.WriteLine("2. Автор");
            Console.WriteLine("3. Вид издания");
            Console.WriteLine("4. Место издания");
            Console.WriteLine("5. Название издательства");
            Console.WriteLine("6. Год издания");
            Console.WriteLine("7. Общее кол-во страниц");
            Console.WriteLine("");
            Console.WriteLine("0. Для возврата в главное меню");
            Console.WriteLine("");

            int numToFind = Functions.ReadNumFromConsoleMinMax(0, 7);
            Console.Clear();

            List<Book> searchResults = new List<Book>();

            if (numToFind == 0)
            {
                MainMenu(library);

                return;
            }
            else if (numToFind == 1)
            {
                string partOfName = Functions.ReadStringFromConsole("Введите название или его часть");
                searchResults = library.SearchByName(partOfName);
            }
            else if (numToFind == 2)
            {
                string partOfName = Functions.ReadStringFromConsole("Введите имя автора или его часть");
                searchResults = library.SearchByAuthor(partOfName);
            }
            else if (numToFind == 3)
            {
                Book.TYPE typeToFind = Functions.IntToType(Functions.ChooseType());
                searchResults = library.SearchByType(typeToFind);
            }
            else if (numToFind == 4)
            {
                string partOfCity = Functions.ReadStringFromConsole("Введите город или его часть");
                searchResults = library.SearchByCity(partOfCity);
            }
            else if (numToFind == 5)
            {
                string partOfPublisher = Functions.ReadStringFromConsole("Введите название издательства или его часть");
                searchResults = library.SearchByPublisher(partOfPublisher);
            }
            else if (numToFind == 6)
            {
                int year = Functions.ReadNumFromConsole("Введите год или его часть");
                searchResults = library.SearchByYear(year);
            }
            else if (numToFind == 7)
            {
                int pageCount = Functions.ReadNumFromConsole("Введите число с количеством страниц или его часть");
                searchResults = library.SearchByPageCount(pageCount);
            }

            Console.WriteLine();
            Console.WriteLine("Результаты поиска: ");
            Console.WriteLine();

            if (searchResults.Count == 0)
            {
                Console.WriteLine("К сожалению ничего не найдено");
            }
            else
            {
                for (int indexOfBook = 0; indexOfBook < searchResults.Count; indexOfBook++)
                {
                    Functions.ShowBookString(indexOfBook + 1, searchResults[indexOfBook]);
                }
            }

            Functions.PressAnyKey();
            FindBook(library);
        }

        static void EditBook(int indexEdit, LibraryBase library)
        {
            Book book = library.GetBookByIndex(indexEdit); // взяли книгу по indexEdit

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

            string author2 = "Автор 2 не задан";
            string author3 = "Автор 3 не задан";

            if (book.Author2.Length > 0)
            {
                author2 = book.Author2;
            }

            if (book.Author3.Length > 0)
            {
                author3 = book.Author3;
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Выберите поле, которое хотите изменить:");
            Console.WriteLine();
            Console.WriteLine("1. Название книги (" + book.Name + ")");
            Console.WriteLine("2. Авторы (" + book.Author1 + ", " + author2 + ", " + author3 + ")");
            Console.WriteLine("3. Вид издания (" + type + ")");
            Console.WriteLine("4. Место издания (" + book.City + ")");
            Console.WriteLine("5. Название издательства (" + book.Publisher + ")");
            Console.WriteLine("6. Год издания (" + book.Year + ")");
            Console.WriteLine("7. Общее кол-во страниц (" + book.PagesCount + ")");
            Console.WriteLine("");
            Console.WriteLine("0. Для возврата в главное меню");
            Console.WriteLine("");

            int numToEdit = Functions.ReadNumFromConsoleMinMax(0, 7);

            if (numToEdit == 1)
            {
                string newName = Functions.ReadStringFromConsole("Введите новое название книги");

                book.Name = newName;
            }
            else if (numToEdit == 2)
            {
                // массив состоящий из трех элементов: 0,1,2
                string[] authors = AddAuthors();

                book.Author1 = authors[0];
                book.Author2 = authors[1];
                book.Author3 = authors[2];
            }
            else if (numToEdit == 3)
            {
                book.Type = Functions.IntToType(Functions.ChooseType());
            }
            else if (numToEdit == 4)
            {
                book.City = Functions.ReadStringFromConsole("Введите новое место издания книги");
            }
            else if (numToEdit == 5)
            {
                book.Publisher = Functions.ReadStringFromConsole("Введите новое название издательства книги");
            }
            else if (numToEdit == 6)
            {
                book.Year = Functions.ReadNumFromConsole("Введите новый год издания");
            }
            else if (numToEdit == 7)
            {
                book.PagesCount = Functions.ReadNumFromConsole("Напишите новое кол-во страниц");
            }
            else if (numToEdit == 0)
            {
                MainMenu(library);
            }

            library.UpdateBookByIndex(indexEdit, book);

            Console.WriteLine("Данные сохранены");
            Functions.PressAnyKey();
            EditBook(indexEdit, library);
        }

        static void ChooseBookToEdit(LibraryBase library)
        {
            Functions.ListOfBooks(library);
            Console.WriteLine("Введите номер книги, которую хотите отредактировать");
            int indexEdit = Functions.ReadNumFromConsoleMinMax(0, library.Count()) - 1;

            if (indexEdit == -1)
            {
                MainMenu(library);
            }
            else if (library.GetBookByIndex(indexEdit) == null)
            {
                Console.WriteLine("Книга с таким номером не найдена");
                ChooseBookToEdit(library);
            }

            EditBook(indexEdit, library);
        }


        static void DeleteBook(LibraryBase library)
        {
            Functions.ListOfBooks(library);

            // будем удалять из массива по этому ключу
            int indexOfBookToDelete = Functions
                .ReadNumFromConsole("Введите номер книги, которую Вы хотите удалить") - 1;

            if (indexOfBookToDelete == -1)
            {
                MainMenu(library);
            }
            else if (library.GetBookByIndex(indexOfBookToDelete) == null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Вы ввели несуществующий номер книги, попробуйте снова");
                DeleteBook(library);
            }

            library.DeleteBookByIndex(indexOfBookToDelete);

            Console.WriteLine("Удаление книги под номером " + (indexOfBookToDelete + 1) + " успешно завершено");

            Functions.PressAnyKey();
            MainMenu(library);
        }

        static void AddBook(LibraryBase library)
        {
            Console.WriteLine("Вы вошли в режим (1) добавления книги");

            // Записываем в переменные результат ввода юзера из консоли
            string[] authors = AddAuthors();
            string name = Functions.ReadStringFromConsole("Введите название книги");
            int type = Functions.ChooseType();
            string place = Functions.ReadStringFromConsole("Введите место издания книги");
            string publisher = Functions.ReadStringFromConsole("Введите название издательства книги");
            int year = Functions.ReadNumFromConsole("Введите год издания");
            int pages = Functions.ReadNumFromConsole("Напишите кол-во страниц");

            Book book = new Book(
                name,
                Functions.IntToType(type),
                place,
                publisher,
                year,
                pages,
                authors[0],
                authors[1],
                authors[2]
            );

            library.Add(book);
            Console.WriteLine("");
            Console.WriteLine("Книга была успешно добавлена");

            Functions.PressAnyKey();
            MainMenu(library);
        }

        protected static string[] AddAuthors()
        {
            string[] authors = new string[] {"", "", ""};

            while (authors[0].Length < 6 || !Regex.IsMatch(authors[0], @"^[А-Яа-яA-Za-z]{1,}"))
            {
                Console.Write("Введите ФИО первого автора: ");
                authors[0] = Console.ReadLine();
            }

            Console.Write("Введите ФИО второго автора (если не хотите вводить, то нажмите ENTER): ");
            authors[1] = Console.ReadLine();

            if (authors[1].Length != 0)
            {
                Console.Write("Введите ФИО третьего автора (если не хотите вводить, то нажмите ENTER): ");
                authors[2] = Console.ReadLine();
            }

            return authors;
        }
    }
}