using System;
using System.Windows.Forms;
using ClassesDll;

namespace FormsLibrary
{
    public partial class FormAddBook : Form
    {
        public FormAddBook()
        {
            InitializeComponent();

            textBoxBookName.Focus();
            textBoxBookName.Select();
        }
     
        protected virtual void buttonAddBookFinish_Click(object sender, EventArgs e)
        {
            Book.TYPE type = Book.TYPE.Book;

            if (radioButtonMagazine.Checked)
            {
                type = Book.TYPE.Magazine;
            }
            else if (radioButtonNewspaper.Checked)
            {
                type = Book.TYPE.Newspaper;
            }

            string authorFio1 = textBoxFio1.Text.Trim();
            string authorFio2 = textBoxFio2.Text.Trim();
            string authorFio3 = textBoxFio3.Text.Trim();

            string name = textBoxBookName.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string publisher = textBoxPublisher.Text.Trim();

            int year = int.Parse(numericUpDownYear.Text.Trim());
            int pages = int.Parse(numericUpDownPages.Text.Trim());

            Book book = new Book(
                name,
                type,
                city,
                publisher,
                year,
                pages,
                authorFio1,
                authorFio2,
                authorFio3
            );

            FormMain.Library.Add(book);

            Close();
            MessageBox.Show("Книга успешно добавлена!");
        }

        private void timerButtonEnable_Tick(object sender, EventArgs e)
        {
            bool name = textBoxBookName.Text.Length >= 1;
            bool type = radioButtonBook.Checked || radioButtonNewspaper.Checked || radioButtonMagazine.Checked;
            bool fio = textBoxFio1.Text.Length >= 6;
            bool city = textBoxCity.Text.Length >= 2;
            bool publisher = textBoxPublisher.Text.Length >= 2;
            bool year = numericUpDownYear.Text.Length >= 1;
            bool pages = numericUpDownPages.Text.Length >= 1;

            if (name && fio && type && city && publisher && year && pages)
            {
                buttonSaveBook.Enabled = true;
            }
            else
            {
                buttonSaveBook.Enabled = false;
            }

            // buttonAddBookFinish.Enabled = fio && type && city && publisher && year && pages;
        }
    }
}
