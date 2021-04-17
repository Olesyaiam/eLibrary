namespace ClassesDll
{
    // интерфейс это сборник функций, которые точно есть во всех наследниках
    public interface ILibrary
    {
        public void Add(Book book);

        public int Count();

        public Book GetBookByIndex(int index);
        public void DeleteBookByIndex(int index);

        void UpdateBookByIndex(int indexEdit, Book book);
    }
}