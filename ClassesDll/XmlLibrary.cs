using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ClassesDll
{
    public class XmlLibrary : LibraryBase
    {
        private XDocument _library;

        public XmlLibrary()
        {
            XElement xmlLibrary = new XElement("Library");

            if (File.Exists(GetFilePath()))
            {
                LoadFromFile();
            }
            else
            {
                _library = new XDocument(xmlLibrary);
            }
        }

        public override void Add(Book book)
        {
            //                          название тега, содержимое тега
            XElement bookName = new XElement("Name", book.Name);
            XElement bookType = new XElement("Type", book.Type);
            XElement bookCity = new XElement("City", book.City);
            XElement bookPublisher = new XElement("Publisher", book.Publisher);
            XElement bookYear = new XElement("Year", book.Year);
            XElement bookPagesCount = new XElement("PagesCount", book.PagesCount);
            XElement bookAuthor1 = new XElement("Author1", book.Author1);
            XElement bookAuthor2 = new XElement("Author2", book.Author2);
            XElement bookAuthor3 = new XElement("Author3", book.Author3);

            // создаем тег Book который содержит в себе другие теги
            XElement xmlBook = new XElement(
                "Book",
                bookName,
                bookType,
                bookCity,
                bookPublisher,
                bookYear,
                bookPagesCount,
                bookAuthor1,
                bookAuthor2,
                bookAuthor3
            );

            _library.Element("Library")?.Add(xmlBook);

            SaveToFile();
        }

        public override int Count()
        {
            // ReSharper disable once PossibleInvalidOperationException
            return (int)_library.Element("Library")?.Elements("Book").Count();
        }

        // задача этого метода: получаем книгу по индексу (по порядковому номеру), если книга по указанному
        // индексу не сущ. то возвращаем нулл
        public override Book GetBookByIndex(int index)
        {
            // 	<Book>
            //     <Name>Компьютерщики</Name>
            //     <Type>3</Type>
            //     <City>Калининград</City>
            //     <Publisher>Книги электронной почтой</Publisher>
            //     <Year>2004</Year>
            //     <PagesCount>125</PagesCount>
            //     <Author1>Иванов Г.Е.</Author1>
            //     <Author2>Тимофеев К. Д.</Author2>
            //     <Author3>Дорофеев А. Н.</Author3>
            // </Book>
            XElement oneFullBook;

            try
            {
                // достаем из базы данных кусок XML-кода (тэг book), содержащий в себе поля конкретной книги
                oneFullBook = _library.Element("Library")?.Elements("Book").ElementAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }

            if (oneFullBook == null)
            {
                return null;
            }

            // из книги достаем конкретные поля и записываем их в переменные
            string bookName = oneFullBook.Element("Name")?.Value;
            string bookType = oneFullBook.Element("Type")?.Value;
            string bookCity = oneFullBook.Element("City")?.Value;
            string bookPublisher = oneFullBook.Element("Publisher")?.Value;
            int bookPagesCount = Int32.Parse(oneFullBook.Element("PagesCount")?.Value ?? string.Empty);
            int bookYear = Int32.Parse(oneFullBook.Element("Year")?.Value ?? string.Empty);
            string bookAuthor1 = oneFullBook.Element("Author1")?.Value;
            string bookAuthor2 = oneFullBook.Element("Author2")?.Value;
            string bookAuthor3 = oneFullBook.Element("Author3")?.Value;

            Book.TYPE type = Book.TYPE.Book;

            if (bookType == Book.TYPE.Newspaper.ToString())
            {
                type = Book.TYPE.Newspaper;
            }
            else if (bookType == Book.TYPE.Magazine.ToString())
            {
                type = Book.TYPE.Magazine;
            }

            // создаем экземпляр класса (объект) book,
            // и заполняем его данными (которые были тэгами в XML)  

            return new Book(
                bookName,
                type,
                bookCity,
                bookPublisher,
                bookYear,
                bookPagesCount,
                bookAuthor1,
                bookAuthor2,
                bookAuthor3
            );
        }

        public override void DeleteBookByIndex(int index)
        {
            try
            {
                // делаем удаление книги по индексу, которой не существует
                _library.Element("Library")?.Elements("Book").ElementAt(index).Remove();
            }
            // в catch не обязательно писать тело, главное чтобы он был просто написан, тогда проигнорирует ошибку
            catch (ArgumentOutOfRangeException)
            {
            }

            SaveToFile();
        }

        public override void UpdateBookByIndex(int indexEdit, Book book)
        {
            XElement oneFullBook;

            try
            {
                // достаем из базы данных кусок XML-кода (тэг book), содержащий в себе поля конкретной книги
                oneFullBook = _library.Element("Library")?.Elements("Book").ElementAt(indexEdit);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            if (oneFullBook == null)
            {
                return;
            }

            XElement nameElement = oneFullBook.Element("Name");

            if (nameElement != null)
            {
                nameElement.Value = book.Name;
            }

            XElement typeElement = oneFullBook.Element("Type");

            if (typeElement != null)
            {
                typeElement.Value = book.Type.ToString();
            }

            XElement cityElement = oneFullBook.Element("City");

            if (cityElement != null)
            {
                cityElement.Value = book.City;
            }

            XElement publisherElement = oneFullBook.Element("Publisher");

            if (publisherElement != null)
            {
                publisherElement.Value = book.Publisher;
            }

            XElement yearElement = oneFullBook.Element("Year");

            if (yearElement != null)
            {
                yearElement.Value = book.Year.ToString();
            }

            XElement pagesCountElement = oneFullBook.Element("PagesCount");

            if (pagesCountElement != null)
            {
                pagesCountElement.Value = book.PagesCount.ToString();
            }

            XElement author1Element = oneFullBook.Element("Author1");

            if (author1Element != null)
            {
                author1Element.Value = book.Author1;
            }

            XElement author2Element = oneFullBook.Element("Author2");

            if (author2Element != null)
            {
                author2Element.Value = book.Author2;
            }

            XElement author3Element = oneFullBook.Element("Author3");

            if (author3Element != null)
            {
                author3Element.Value = book.Author3;
            }

            SaveToFile();
        }

        private void SaveToFile()
        {
            File.WriteAllText(GetFilePath(), _library.ToString());
        }

        private void LoadFromFile()
        {
            string rawXmlString = File.ReadAllText(GetFilePath());

            _library = XDocument.Parse(rawXmlString);
        }

        public string GetFilePath()
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return Path.Combine(myDocuments, "ZhigalovaLibrary.xml");
        }
    }
}