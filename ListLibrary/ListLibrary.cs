using System;
using System.Collections.Generic;
using ClassesDll;

namespace ListLibrary
{
    public class ListLibrary : LibraryBase
    {
        private readonly List<Book> _library = new List<Book>();

        public void Add(Book book)
        {
            _library.Add(book);
        }

        public int Count()
        {
            return _library.Count;
        }

        public Book GetBookByIndex(int index)
        {
            try
            {
                return _library[index];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void DeleteBookByIndex(int index)
        {
            _library.RemoveAt(index);
        }

        public void UpdateBookByIndex(int indexOfBook, Book book)
        {
            _library[indexOfBook] = book;
        }
    }
}