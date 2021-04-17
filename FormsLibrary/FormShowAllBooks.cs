using System.Windows.Forms;
using ClassesDll;

namespace FormsLibrary
{
    public partial class FormShowAllBooks : Form
    {
        public FormShowAllBooks()
        {
            InitializeComponent();

            labelTextAction.Hide();
            numericUpDownActionNumber.Hide();
            buttonAction.Hide();
            UpdateBooksOnScreen();
        }

        public void UpdateBooksOnScreen()
        {
            richTextBoxBooks.Text = "";

            for (int indexOfBook = 0; indexOfBook < FormMain.Library.Count(); indexOfBook++)
            {
                Book book = FormMain.Library.GetBookByIndex(indexOfBook);
                int bookNumber = indexOfBook + 1;

                string bookString = Functions.GetBookString(bookNumber, book);

                richTextBoxBooks.Text += bookString + "\r\n\r\n";
            }
        }
    }
}
