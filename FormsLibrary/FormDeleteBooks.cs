using System;
using System.Windows.Forms;

namespace FormsLibrary 
{
    class FormDeleteBooks : FormShowAllBooks
    {
        public FormDeleteBooks()
        {
            labelTitle.Text = "Вы вошли в режим удаления книг";
            Text = "Удаление книг";
            labelTextAction.Text = "Введите номер книги, которую хотите удалить: ";
            buttonAction.Text = "Удалить";

            labelTextAction.Show();
            numericUpDownActionNumber.Show();
            buttonAction.Show();
            buttonAction.Click += buttonAction_Click;
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            int bookNumberToDelete = int.Parse(numericUpDownActionNumber.Text);
            int bookIndex = bookNumberToDelete - 1;

            if (FormMain.Library.GetBookByIndex(bookIndex)==null)
            {
                MessageBox.Show("Такой книги не существует");
            }
            else
            {
                FormMain.Library.DeleteBookByIndex(bookIndex);
                MessageBox.Show("Книга успешно удалена");
                UpdateBooksOnScreen();
            }

        }
    }
}
