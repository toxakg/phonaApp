using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace phonaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();  // ������������� ���� ������
            UpdateGrid();  // �������� Grid ��� �������
        }

        public class Phone
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string Brand { get; set; }
            public decimal Price { get; set; }
        }

        // ����� ��� ������������� ���� ������ � �������� �������
        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection("Data Source=phones.db;"))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Phones (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Model TEXT NOT NULL,
                        Brand TEXT NOT NULL,
                        Price REAL NOT NULL
                    );
                ";
                var command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        // ����� ��� ���������� �������� � ���� ������
        private void AddPhoneToDatabase(string model, string brand, decimal price)
        {
            using (var connection = new SQLiteConnection("Data Source=phones.db;"))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Phones (Model, Brand, Price) VALUES (@Model, @Brand, @Price)";
                var command = new SQLiteCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Model", model);
                command.Parameters.AddWithValue("@Brand", brand);
                command.Parameters.AddWithValue("@Price", price);
                command.ExecuteNonQuery();
            }
        }

        // ����� ��� ��������� ���� ��������� �� ���� ������
        private List<Phone> GetPhonesFromDatabase()
        {
            var phones = new List<Phone>();

            using (var connection = new SQLiteConnection("Data Source=phones.db;"))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Phones";
                var command = new SQLiteCommand(selectQuery, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phone = new Phone
                        {
                            Id = reader.GetInt32(0),
                            Model = reader.GetString(1),
                            Brand = reader.GetString(2),
                            Price = reader.GetDecimal(3)
                        };
                        phones.Add(phone);
                    }
                }
            }

            return phones;
        }

        // ����� ��� ���������� DataGridView � ���������� �� ���� ������
        private void UpdateGrid()
        {
            var phones = GetPhonesFromDatabase();
            dataGridViewPhones.DataSource = phones;
        }

        // ���������� ������ "�������� �������"
        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            string model = txtModel.Text;
            string brand = txtBrand.Text;
            decimal price;

            if (string.IsNullOrEmpty(model) || string.IsNullOrEmpty(brand))
            {
                MessageBox.Show("������ � ����� �� ����� ���� �������.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("������� ���������� ����.");
                return;
            }

            AddPhoneToDatabase(model, brand, price);  // ��������� ������� � ���� ������
            UpdateGrid();  // ��������� DataGrid
        }

        // ����� �� ������
        private void SearchPhones(string model)
        {
            var phones = GetPhonesFromDatabase();
            var result = phones.Where(p => p.Model.Contains(model)).ToList();
            MessageBox.Show($"������� {result.Count} ��������(��) �� ������� \"{model}\".");

            dataGridViewPhones.DataSource = result;
        }

        // ���������� ������ "�����"
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string model = txtSearchModel.Text;
            SearchPhones(model);
        }

        // ��������� ��������
        private void btnEditPhone_Click(object sender, EventArgs e)
        {
            if (dataGridViewPhones.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ������� ��� ���������.");
                return;
            }

            var selectedRow = dataGridViewPhones.SelectedRows[0];
            var selectedPhone = (Phone)selectedRow.DataBoundItem;

            txtModel.Text = selectedPhone.Model;
            txtBrand.Text = selectedPhone.Brand;
            txtPrice.Text = selectedPhone.Price.ToString();

            // ������� ������ "��������" �� "��������� ���������"
            btnAddPhone.Text = "��������� ���������";
            btnAddPhone.Click -= btnAddPhone_Click;
            btnAddPhone.Click += (s, e2) =>
            {
                selectedPhone.Model = txtModel.Text;
                selectedPhone.Brand = txtBrand.Text;
                selectedPhone.Price = decimal.Parse(txtPrice.Text);
                UpdatePhoneInDatabase(selectedPhone);  // ��������� ������� � ���� ������
                UpdateGrid();  // ��������� DataGrid
                btnAddPhone.Text = "�������� �������";
                btnAddPhone.Click -= (s2, e3) => { };
                btnAddPhone.Click += btnAddPhone_Click;
            };
        }

        // ����� ��� ���������� ������ �������� � ���� ������
        private void UpdatePhoneInDatabase(Phone phone)
        {
            using (var connection = new SQLiteConnection("Data Source=phones.db;"))
            {
                connection.Open();
                string updateQuery = "UPDATE Phones SET Model = @Model, Brand = @Brand, Price = @Price WHERE Id = @Id";
                var command = new SQLiteCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@Id", phone.Id);
                command.Parameters.AddWithValue("@Model", phone.Model);
                command.Parameters.AddWithValue("@Brand", phone.Brand);
                command.Parameters.AddWithValue("@Price", phone.Price);
                command.ExecuteNonQuery();
            }
        }

        // �������� ��������
        private void btnDeletePhone_Click(object sender, EventArgs e)
        {
            if (dataGridViewPhones.SelectedRows.Count == 0)
            {
                MessageBox.Show("�������� ������� ��� ��������.");
                return;
            }

            var selectedRow = dataGridViewPhones.SelectedRows[0];
            var selectedPhone = (Phone)selectedRow.DataBoundItem;

            var result = MessageBox.Show($"�� �������, ��� ������ ������� ������� {selectedPhone.Model}?", "�������������", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeletePhoneFromDatabase(selectedPhone.Id);  // ������� ������� �� ���� ������
                UpdateGrid();  // ��������� DataGrid
            }
        }

        // ����� ��� �������� �������� �� ���� ������
        private void DeletePhoneFromDatabase(int phoneId)
        {
            using (var connection = new SQLiteConnection("Data Source=phones.db;"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Phones WHERE Id = @Id";
                var command = new SQLiteCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@Id", phoneId);
                command.ExecuteNonQuery();
            }
        }
    }
}
