using System.Collections.Generic;
using System.Windows.Forms;
using ClassesDll;

namespace FormsLibrary
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = 0;

            UpdateBooksOnScreen(FormMain.Library.GetAllBooks());
        }

        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            List<Book> searchResults = new List<Book>();

            int? year = null;

            if (checkBoxYear.Checked)
            {
                year = int.Parse(numericUpDownYear.Text);
            }

            int? pages = null;

            if (checkBoxPages.Checked)
            {
                pages = int.Parse(numericUpDownPages.Text);
            }

            Book.TYPE? type = null;

            if (comboBoxType.SelectedIndex == 1)
            {
                type = Book.TYPE.Book;
            } 
            else if (comboBoxType.SelectedIndex == 2)
            {
                type = Book.TYPE.Magazine;
            } 
            else if (comboBoxType.SelectedIndex == 3)
            {
                type = Book.TYPE.Newspaper;
            }

            searchResults = FormMain.Library.SearchByAll(
                textBoxName.Text,
                textBoxAuthor.Text,
                type,
                textBoxCity.Text,
                textBoxPublisher.Text,
                year,
                pages
            );

            UpdateBooksOnScreen(searchResults);
        }
        private void UpdateBooksOnScreen(List<Book> searchResults)
        {
            richTextBoxSearchResults.Text = "";

            for (int indexOfBook = 0; indexOfBook < searchResults.Count; indexOfBook++)
            {
                Book book = searchResults[indexOfBook];
                int bookNumber = indexOfBook + 1;

                string bookString = Functions.GetBookString(bookNumber, book);

                richTextBoxSearchResults.Text += bookString + "\r\n\r\n";
            }
        }

        private void checkBoxPages_CheckedChanged(object sender, System.EventArgs e)
        {
            numericUpDownPages.Enabled = checkBoxPages.Checked;
        }

        private void checkBoxYear_CheckedChanged(object sender, System.EventArgs e)
        {
            numericUpDownYear.Enabled = checkBoxYear.Checked;
        }
    }
}
