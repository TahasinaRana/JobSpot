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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        public bool executeQuery2(string query)
        {


            SqlConnection con = new SqlConnection(@"Data Source=Mahi\SQLEXPRESS01;Initial Catalog=JobSpot1DB;Integrated Security=True;Encrypt=False;");

            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)

            { return true; }
            else return false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string upd = $"Update[JobSpot1DB].[dbo].[SignUp] SET Password = '{txtPassd.Text}', Phone_Number = '{txtNumb.Text}' WHERE[Full_Name] = 'l{LoginForm.name}'";
            if (executeQuery2(upd))
            {
                MessageBox.Show("Update Successful");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }

        }
    }
}
