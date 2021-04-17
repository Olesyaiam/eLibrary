using System;
using System.Collections.Generic;

namespace ClassesDll
{
    public class LibraryBase
    {
        protected LibraryBase()
        {
        }

        public virtual void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public virtual List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < Count(); indexOfBook++)
            {
                allBooks.Add(GetBookByIndex(indexOfBook));
            }

            return allBooks;
        }


        public virtual int Count()
        {
            throw new NotImplementedException();
        }

        public virtual Book GetBookByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteBookByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateBookByIndex(int indexEdit, Book book)
        {
            throw new NotImplementedException();
        }

        // вернуть результат поиска книг
        public List<Book> SearchByAuthor(string searchString)
        {
            return SearchByAuthor(searchString, GetAllBooks());
        }

        public List<Book> SearchByAuthor(string searchString, List<Book> books)
        {
            searchString = searchString.ToLower();
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null)
                {
                    string author1 = book.Author1.ToLower();
                    string author2 = book.Author2.ToLower();
                    string author3 = book.Author3.ToLower();

                    if (author1.Contains(searchString) || author2.Contains(searchString) ||
                        author3.Contains(searchString))
                    {
                        searchResult.Add(book);
                    }
                }
            }

            return searchResult;
        }

        public List<Book> SearchByType(Book.TYPE type)
        {
            return SearchByType(type, GetAllBooks());
        }
        public List<Book> SearchByType(Book.TYPE type, List<Book> books)
        {
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null && book.Type == type)
                {
                    searchResult.Add(book);
                }
            }

            return searchResult;
        }

        public List<Book> SearchByCity(string searchString)
        {
            return SearchByCity(searchString, GetAllBooks());
        }

        public List<Book> SearchByCity(string searchString, List<Book> books)
        {
            searchString = searchString.ToLower();
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null)
                {
                    string city = book.City.ToLower();

                    if (city.Contains(searchString))
                    {
                        searchResult.Add(book);
                    }
                }
            }

            return searchResult;
        }

        public List<Book> SearchByPublisher(string searchString)
        {
            return SearchByPublisher(searchString, GetAllBooks());
        }

        public List<Book> SearchByPublisher(string searchString, List<Book> books)
        {
            searchString = searchString.ToLower();
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null)
                {
                    string publisher = book.Publisher.ToLower();

                    if (publisher.Contains(searchString))
                    {
                        searchResult.Add(book);
                    }
                }
            }

            return searchResult;
        }

        public List<Book> SearchByYear(int search)
        {
            return SearchByYear(search, GetAllBooks());
        }

        public List<Book> SearchByYear(int search, List<Book> books)
        {
            string searchString = search.ToString();
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null)
                {
                    string year = book.Year.ToString();

                    if (year.Contains(searchString))
                    {
                        searchResult.Add(book);
                    }
                }
            }

            return searchResult;
        }

        public List<Book> SearchByPageCount(int search)
        {
            return SearchByPageCount(search, GetAllBooks());
        }

        public List<Book> SearchByPageCount(int search, List<Book> books)
        {
            string searchString = search.ToString();
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null)
                {
                    string pageCount = book.PagesCount.ToString();

                    if (pageCount.Contains(searchString))
                    {
                        searchResult.Add(book);
                    }
                }
            }

            return searchResult;
        }

        public List<Book> SearchByName(string searchString)
        {
            return SearchByName(searchString, GetAllBooks());
        }

        public List<Book> SearchByName(string searchString, List<Book> books)
        {
            searchString = searchString.ToLower();
            List<Book> searchResult = new List<Book>();

            for (int indexOfBook = 0; indexOfBook < books.Count; indexOfBook++)
            {
                Book book = books[indexOfBook];

                if (book != null)
                {
                    string name = book.Name.ToLower();

                    if (name.Contains(searchString))
                    {
                        searchResult.Add(book);
                    }
                }
            }

            return searchResult;
        }

#pragma warning disable 8632
        public List<Book> SearchByAll(string? nameBook, string? author, Book.TYPE? type, string? city, string? publisher, int? year, int? pages)
#pragma warning restore 8632
        {
#pragma warning disable 8604
            List<Book> searchResults = GetAllBooks();

            if (!string.IsNullOrEmpty(nameBook))
            {
                searchResults = SearchByName(nameBook, searchResults);
            }

            if (!string.IsNullOrEmpty(author))
            {
                searchResults = SearchByAuthor(author, searchResults);
            }

            if (!string.IsNullOrEmpty(city))
            {
                searchResults = SearchByCity(city, searchResults);
            }

            if (!string.IsNullOrEmpty(publisher))
            {
                searchResults = SearchByPublisher(publisher, searchResults);
            }

            if (type != null)
            {
                searchResults = SearchByType((Book.TYPE)type, searchResults);
            }

            if (pages != null)
            {
                searchResults = SearchByPageCount((int)pages, searchResults);
            }

            if (year != null)
            {
                searchResults = SearchByYear((int)year, searchResults);
            }

            return searchResults;
#pragma warning restore 8604
        }
    }
}