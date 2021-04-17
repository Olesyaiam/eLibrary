using System;
using System.Windows.Forms;
using ClassesDll;

namespace FormsLibrary 
{
    class FormSelectBooksForEdit : FormShowAllBooks
    {
        private FormEditBook _formEditBook;

        public FormSelectBooksForEdit()
        {
            labelTitle.Text = "Вы вошли в режим редактирования книг";
            Text = "Редактирование книг";
            labelTextAction.Text = "Введите номер книги для редактирования: ";
            buttonAction.Text = "Редактировать";

            labelTextAction.Show();
            numericUpDownActionNumber.Show();
            buttonAction.Show();
            buttonAction.Click += buttonAction_Click;
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            int bookNumberToEdit = int.Parse(numericUpDownActionNumber.Text);
            int bookIndex = bookNumberToEdit - 1;
            Book book = FormMain.Library.GetBookByIndex(bookIndex);

            if (book == null)
            {
                MessageBox.Show("Такой книги не существует");
            }
            else
            {
                // чтобы не открывалось несколько окошек
                // и не было Exception "Cannot access a disposed object"
                if (_formEditBook == null || _formEditBook.IsDisposed)
                {
                    _formEditBook = new FormEditBook(book,bookIndex,this);
                }

                _formEditBook.Show();
            }
        }
    }
}
