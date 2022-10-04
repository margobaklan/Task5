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
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Назва";
            dataGridView1.Columns[1].Name = "Ціна";
            dataGridView1.Columns[2].Name = "Країна походження";
            dataGridView1.Columns[3].Name = "Дата пакування";
            dataGridView1.Columns[4].Name = "Деталі";
            dataGridView1.Columns[5].Name = "Термін придатності";
            dataGridView1.Columns[6].Name = "Кількість";
            dataGridView1.Columns[7].Name = "Одиниця виміру";

            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Назва";
            dataGridView2.Columns[1].Name = "Ціна";
            dataGridView2.Columns[2].Name = "Країна походження";
            dataGridView2.Columns[3].Name = "Дата пакування";
            dataGridView2.Columns[4].Name = "Деталі";
            dataGridView2.Columns[5].Name = "Кількість сторінок";
            dataGridView2.Columns[6].Name = "Видавництво";
            dataGridView2.Columns[7].Name = "Перелік авторів";
        }
        private void DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            var editedCell = this.dataGridView2.Rows[row].Cells[col];
            var newValue = editedCell.Value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addData1(toolStripTextBox1.Text);
        }

        private void addData1(string name)
        {
            Book book = new Book(name);
            books.Add(book);
            string price = book.Price.ToString();
            string country = book.Country;
            string dataPackage = book.DatePackage.ToString();
            string details = book.Details;
            string quantityPages = book.QuantityPages.ToString();
            string publishingHouse = book.PublishingHouse;
            string authors = book.Authors;
            String[] row = { name, price, country, dataPackage, details, quantityPages, publishingHouse, authors };
            dataGridView1.Rows.Add(row);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            addData2(toolStripTextBox1.Text);
        }

        private void addData2(string name)
        {
            Groceries grocerie = new Groceries(name);
            groceries.Add(grocerie);
            string price = grocerie.Price.ToString();
            string country = grocerie.Country;
            string dataPackage = grocerie.DatePackage.ToString();
            string details = grocerie.Details;
            string expiration = grocerie.Expiration.ToString();
            string quantity = grocerie.Quantity.ToString();
            string unit = grocerie.Unit;
            String[] row = { name, price, country, dataPackage, details, expiration, quantity, unit};
            dataGridView2.Rows.Add(row);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int check1 = CheckPresence(toolStripTextBox1.Text, dataGridView1);
            int check2 = CheckPresence(toolStripTextBox1.Text, dataGridView2); 
            DeleteRow(toolStripTextBox1.Text, dataGridView1);
            DeleteRow(toolStripTextBox1.Text, dataGridView2);
            if (check1 == 0 && check2 == 0)
            {
                MessageBox.Show("Товару з такою назвою не існує");
            }
        }

        private int CheckPresence(string name, DataGridView dataGridView)
        {
            List<int> k = FindRow(name, dataGridView);
            return k.Count;
        }
        private void DeleteRow(string name, DataGridView dataGridView)
        {
            List<int> k = FindRow(name, dataGridView);
            if (k.Count != 0)
            {
                for (int i = 0; i < k.Count; i++)
                {
                    dataGridView.Rows.Remove(dataGridView.Rows[k[i]-i]);
                }
            }
        }

        private List<int> FindRow(string name, DataGridView dataGridView)
        {
            List<int> ColumnIndex1 = new List<int>();
            int j = dataGridView.Rows.Count;
            for (int i = 0; i < j-1; i++)
            {
                var row = dataGridView.Rows[i];
                if (row.Cells[0].Value.ToString() == name)
                {
                    ColumnIndex1.Add(i);
                }
            }
            return ColumnIndex1;
        }
    }
}
