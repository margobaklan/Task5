using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        List<Book> books = new List<Book>();
        List<Groceries> groceries = new List<Groceries>();

        public Form1()
        {
            InitializeComponent();
            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Назва";
            dataGridView2.Columns[1].Name = "Ціна";
            dataGridView2.Columns[2].Name = "Країна походження";
            dataGridView2.Columns[3].Name = "Дата пакування";
            dataGridView2.Columns[4].Name = "Деталі";
            dataGridView2.Columns[5].Name = "Термін придатності";
            dataGridView2.Columns[6].Name = "Кількість";
            dataGridView2.Columns[7].Name = "Одиниця виміру";

            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Назва";
            dataGridView1.Columns[1].Name = "Ціна";
            dataGridView1.Columns[2].Name = "Країна походження";
            dataGridView1.Columns[3].Name = "Дата пакування";
            dataGridView1.Columns[4].Name = "Деталі";
            dataGridView1.Columns[5].Name = "Кількість сторінок";
            dataGridView1.Columns[6].Name = "Видавництво";
            dataGridView1.Columns[7].Name = "Перелік авторів";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addData1(toolStripTextBox1.Text);
        }

        private void addData1(string name)
        {
            decimal price = 0;
            string country = "";
            DateTime dataPackage = new DateTime();
            string details = "";
            int quantityPages = 0;
            string publishingHouse = "";
            string authors = "";
            Book b = new Book(name, price, country, dataPackage, details, quantityPages, publishingHouse, authors);
            books.Add(b);
            dataGridView1.Rows.Add(b.Name, b.Price, b.Country, b.DatePackage, b.Details, b.QuantityPages, b.PublishingHouse, b.Authors);

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            addData2(toolStripTextBox1.Text);
        }
        private void addData2(string name)
        {
            decimal price = 0;
            string country = "";
            DateTime dataPackage = new DateTime();
            string details = "";
            DateTime expiration = new DateTime();
            int quantity = 0;
            string unit = "";
            Groceries g = new Groceries(name, price, country, dataPackage, details, expiration, quantity, unit);
            groceries.Add(g);            
            dataGridView2.Rows.Add(g.Name, g.Price, g.Country, g.DatePackage, g. Details, g.Expiration, g.Quantity, g.Unit);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 || dataGridView2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                    int i = row.Index + 1;
                    books.Remove(books[i]);
                }
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.Remove(row);
                    int i = row.Index + 1;
                    groceries.Remove(groceries[i]);
                }
            }
            else
            {  
                MessageBox.Show("Please select a row");
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dataGridView1.Rows[row].Cells[col].IsInEditMode == false) { return; }
            try
            {
                if (col == 0) { books[row].Name = e.FormattedValue.ToString(); }
                else if (col == 1) { books[row].Price = Convert.ToDecimal(e.FormattedValue); }
                else if (col == 2) { books[row].Country = e.FormattedValue.ToString(); }
                else if (col == 3) { books[row].DatePackage = Convert.ToDateTime(e.FormattedValue); }
                else if (col == 4) { books[row].Details = e.FormattedValue.ToString(); }
                else if (col == 5) { books[row].QuantityPages = Convert.ToInt32(e.FormattedValue); }
                else if (col == 6) { books[row].PublishingHouse = e.FormattedValue.ToString(); }
                else if (col == 7) { books[row].Authors = e.FormattedValue.ToString(); }
            }
            catch (FormatException)
            {
                dataGridView1.CancelEdit();
                MessageBox.Show("Неправильний формат");
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dataGridView2.Rows[row].Cells[col].IsInEditMode == false) { return; }
            try
            {
                if (col == 0) { groceries[row].Name = e.FormattedValue.ToString(); }
                else if (col == 1) { groceries[row].Price = Convert.ToDecimal(e.FormattedValue); }
                else if (col == 2) { groceries[row].Country = e.FormattedValue.ToString(); }
                else if (col == 3) { groceries[row].DatePackage = Convert.ToDateTime(e.FormattedValue); }
                else if (col == 4) { groceries[row].Details = e.FormattedValue.ToString(); }
                else if (col == 5) { groceries[row].Expiration = Convert.ToDateTime(e.FormattedValue); }
                else if (col == 6) { groceries[row].Quantity = Convert.ToInt32(e.FormattedValue); }
                else if (col == 7) { groceries[row].Unit = e.FormattedValue.ToString(); }
            }
            catch (FormatException)
            {
                dataGridView2.CancelEdit();
                MessageBox.Show("Неправильний формат");
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
    }
}
