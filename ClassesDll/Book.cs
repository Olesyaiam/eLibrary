namespace ClassesDll
{
    public class Book
    {
        // Создание полей класса Book
        public string Name;
        public TYPE Type;
        public string City;
        public string Publisher;
        public int Year;
        public int PagesCount;
        public string Author1;
        public string Author2;
        public string Author3;

        // ReSharper disable once InconsistentNaming
        public enum TYPE
        {
            Book,
            Newspaper,
            Magazine
        }

        // Конструктор, который вызывается при создании экземпляра класса
        public Book(
            string name,
            TYPE type,
            string city,
            string publisher,
            int year,
            int pagesCount,
            string author1,
            string author2 = "",
            string author3 = ""
        )
        {
            Name = name;
            Type = type;
            City = city;
            Publisher = publisher;
            Year = year;
            PagesCount = pagesCount;
            Author1 = author1;
            Author2 = author2;
            Author3 = author3;
        }
    }
}