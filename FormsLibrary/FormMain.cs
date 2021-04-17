using System;
using System.IO;
using System.Windows.Forms;
using ClassesDll;

namespace FormsLibrary
{
    public partial class FormMain : Form
    {
        private FormAddBook _addBookForm;
        private FormShowAllBooks _showAllForm;
        private FormDeleteBooks _deleteBooksForm;
        private FormSelectBooksForEdit _editBooksForm;
        private FormSearch _formSearchForm;
       
        public static XmlLibrary Library;

        public FormMain()
        {
            InitializeComponent();

            Library = new XmlLibrary();

            if (!File.Exists(Library.GetFilePath()))
            {
                Functions.AddDummyBooks(Library);
            }
        }

        private void buttonShowAllBooks_Click(object sender, EventArgs e)
        {
            // чтобы не открывалось несколько окошек
            // и не было Exception "Cannot access a disposed object"
            if (_showAllForm == null || _showAllForm.IsDisposed)
            {
                _showAllForm = new FormShowAllBooks();
            }

            _showAllForm.Show();

        }

        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            // чтобы не открывалось несколько окошек
            // и не было Exception "Cannot access a disposed object"
            if (_editBooksForm == null || _editBooksForm.IsDisposed)
            {
                _editBooksForm = new FormSelectBooksForEdit();
            }

            _editBooksForm.Show();

        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            // чтобы не открывалось несколько окошек
            // и не было Exception "Cannot access a disposed object"
            if (_deleteBooksForm == null || _deleteBooksForm.IsDisposed)
            {
                _deleteBooksForm = new FormDeleteBooks();
            }

            _deleteBooksForm.Show();
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            // чтобы не открывалось несколько окошек
            // и не было Exception "Cannot access a disposed object"
            if (_formSearchForm == null || _formSearchForm.IsDisposed)
            {
                _formSearchForm = new FormSearch();
            }

            _formSearchForm.Show();
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            // чтобы не открывалось несколько окошек
            // и не было Exception "Cannot access a disposed object"
            if (_addBookForm == null || _addBookForm.IsDisposed)
            {
                _addBookForm = new FormAddBook();
            }

            _addBookForm.Show();
        }
    }
}
