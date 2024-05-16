using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JobSpot
{
    public partial class AdminLogin : Form
    {
        public string LoginQuery2(string query)
        {

            SqlConnection con = new SqlConnection(@"Data Source=Mahi\SQLEXPRESS01;Initial Catalog=JobSpot1DB;Integrated Security=True;Encrypt=False;");
            SqlDataAdapter result;

            if (con.State == ConnectionState.Open)
            {
                result = new SqlDataAdapter(query, con);
                con.Close();
            }
            else
            {
                con.Open();
                result = new SqlDataAdapter(query, con);
                con.Close();
            }

            DataTable table = new DataTable();
            result.Fill(table);

            object value = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                value = row[0];
                return value.ToString();
            }
            else
            {
                return "";
            }
        }
        
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qry = $"SELECT [Password] FROM [JobSpot1DB].[dbo].[Login] Where[Username] = '{textBox1.Text}'";
            if (LoginQuery2(qry)== textBox2.Text) {
                Admin adminForm = new Admin();
                adminForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Not Successful");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();

            welcomeForm.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
