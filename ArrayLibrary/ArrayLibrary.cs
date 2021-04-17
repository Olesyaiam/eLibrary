using System;
using ClassesDll;

namespace ArrayLibrary
{
    public class ArrayLibrary : LibraryBase
    {
        private string[][] _library = new string[1000][]; // наша библиотека вмещает в себя 1000 эл. книг

        public void Add(Book book)
        {
            for (int indexOfBook = 0; indexOfBook < _library.Length; indexOfBook++) // проходим по всем ячейкам Library
            {
                if (_library[indexOfBook] == null) // если равен null то нашли свободную ячейку
                {
                    UpdateBookByIndex(indexOfBook, book);

                    return;
                }
            }
        }

        public int Count()
        {
            int count = 0;

            foreach (string[] book in _library)
            {
                if (book != null)
                {
                    count++;
                }
            }

            return count;
        }

        public Book GetBookByIndex(int index)
        {
            try
            {
                if (_library[index] == null)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return new Book(
                _library[index][0], // название
                Functions.IntToType(Int32.Parse(_library[index][1])),
                _library[index][2], // место издания
                _library[index][3], // название издательства
                Int32.Parse(_library[index][4]), // год издания
                Int32.Parse(_library[index][5]), // кол-во страниц
                _library[index][6], // автор 1
                _library[index][7], // автор 2
                _library[index][8] // автор 3
            );
        }

        public void DeleteBookByIndex(int index)
        {
            _library[index] = null;
            ReIndexLibrary();
        }

        private void ReIndexLibrary()
        {
            string[][] libraryNew = new string[1000][];
            int index = 0;

            foreach (string[] book in _library)
            {
                if (book != null)
                {
                    libraryNew[index] = book;
                    index++;
                }
            }

            _library = libraryNew;
        }

        public void UpdateBookByIndex(int indexOfBook, Book book)
        {
            string[] bookArray =
            {
                book.Name,
                Functions.TypeToInt(book.Type).ToString(),
                book.City,
                book.Publisher,
                book.Year.ToString(),
                book.PagesCount.ToString(),
                book.Author1,
                book.Author2,
                book.Author3
            };

            _library[indexOfBook] = bookArray;
        }
    }
}