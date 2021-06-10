using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMau1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataProvider data = new DataProvider();
        void LoadData()
        {
            dgvBook.DataSource = data.GetBooks();
            Account account = data.GetAccount();
            txbUser.Text = account.Username;
            txbPass.Text = account.Password;
        }

        void AddBinding()
        {
            txbAuthor.DataBindings.Add(new Binding("Text", dgvBook.DataSource, "Author"));
            txbTittle.DataBindings.Add(new Binding("Text", dgvBook.DataSource, "Tittle"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            AddBinding();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book(txbAuthor.Text, txbTittle.Text);
            data.AddBook(book);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string tittle = dgvBook.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
            data.DeleteBook(tittle);
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tittle = dgvBook.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
            data.EditBook(txbAuthor.Text, txbTittle.Text, tittle);
            LoadData();
        }
    }
}
