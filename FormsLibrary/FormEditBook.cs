using System;
using System.Windows.Forms;
using ClassesDll;

namespace FormsLibrary
{
    class FormEditBook : FormAddBook
    {
        protected Book Book;
        protected int BookIndex;
        protected FormSelectBooksForEdit FormSelectBooksForEdit;

        public FormEditBook(Book book, int bookIndex,FormSelectBooksForEdit formSelectBooksForEdit)
        {
            // book получаем из базы данных, для работы с ним нужно записать его в параметры конструктора
            // далее от наследованной формы Add получаем форму Edit в которой меняем содержимое полей
            // для редактирования и данные из book'а автоматически записываются в поля 
            Book = book;
            BookIndex = bookIndex;
            FormSelectBooksForEdit = formSelectBooksForEdit;

            Text = "Редактирование книги";
            labelTitle.Text = "Вы вошли в режим редактирования книги";
            buttonSaveBook.Text = "Сохранить";

            // Здесь из полей book'a берутся значения полей и заполняются в значения полей формы
            textBoxBookName.Text = book.Name; // "привет";
            textBoxFio1.Text = book.Author1;
            textBoxFio2.Text = book.Author2;
            textBoxFio3.Text = book.Author3;

            textBoxCity.Text = book.City;
            textBoxPublisher.Text = book.Publisher;
            numericUpDownYear.Text = book.Year.ToString();
            numericUpDownPages.Text = book.PagesCount.ToString();

            // тип текущей книги, которую мы редактируем сравниваем с Book.TYPE это
            // список типов, которые у нас прописаны (журнал, газета, книга)
            if (book.Type == Book.TYPE.Book)
            {
                radioButtonBook.Checked = true;
            }else if (book.Type == Book.TYPE.Magazine)
            {
                radioButtonMagazine.Checked = true;
            }else if (book.Type == Book.TYPE.Newspaper)
            {
                radioButtonNewspaper.Checked = true;
            }
        }

        protected override void buttonAddBookFinish_Click(object sender, EventArgs e)
        {
            Book.Name = textBoxBookName.Text;
            Book.Author1 = textBoxFio1.Text;
            Book.Author2 = textBoxFio2.Text;
            Book.Author3 = textBoxFio3.Text;
            Book.City = textBoxCity.Text;
            Book.Publisher = textBoxPublisher.Text;
            Book.Year = Int32.Parse(numericUpDownYear.Text);
            Book.PagesCount = Int32.Parse(numericUpDownPages.Text);

            if (radioButtonBook.Checked)
            {
                Book.Type = Book.TYPE.Book;
            }else if (radioButtonMagazine.Checked)
            {
                Book.Type = Book.TYPE.Magazine;
            }else if (radioButtonNewspaper.Checked)
            {
                Book.Type = Book.TYPE.Newspaper;
            }

            FormMain.Library.UpdateBookByIndex(BookIndex,Book);
            MessageBox.Show("Книга успешно отредактирована!");
            Close();
            FormSelectBooksForEdit.UpdateBooksOnScreen();
        }
    }
}
