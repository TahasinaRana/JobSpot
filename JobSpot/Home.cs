using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobSpot
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            LoadData();
        }

        private void searchButton_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            string searchText = searchButton.Text;
            string query = $"SELECT * FROM [JobSpot1DB].[dbo].[Jobs] WHERE [Company_Name] LIKE '%{searchText}%' OR Position LIKE '%{searchText}%' OR Salary LIKE '%{searchText}%'";
            FillDataGridView(query);
        }

        private void contact_Click(object sender, EventArgs e)
        {
            Contact contactForm = new Contact();

            contactForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings SettingsForm = new Settings();

            SettingsForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string query = "SELECT * FROM Jobs";
            FillDataGridView(query);
        }

        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source = Mahi\SQLEXPRESS01; Initial Catalog = JobSpot1DB; Integrated Security = True; Encrypt = False;"))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
