using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JobSpot
{
    public partial class LoginForm : Form
    {
        public bool executeQuery2(string query)
        {


            SqlConnection con = new SqlConnection(@"Data Source=Aspire_3\SQLEXPRESS;Initial Catalog=TransfusionBD;Integrated Security=True");

        SqlCommand command = new SqlCommand(query, con);

        con.Open();
 
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
 
                { return true; }
                else return false;

        }
    public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public static string name = "";
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
        private void button2_Click(object sender, EventArgs e)
        {
            string qry = $"SELECT [Password] FROM [JobSpot1DB].[dbo].[SignUp] Where [Full_Name] = '{txtName.Text}'";
            if (LoginQuery2(qry) == txtPass.Text)
            {

                Home homeForm = new Home();

                homeForm.Show();

                this.Hide();
                name=txtName.Text;  
            }
            else
            {
                MessageBox.Show("Login Not Successful");
            }

           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPass.Checked==false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            SelectType selectTypeForm = new SelectType();

            selectTypeForm.Show();

            this.Close();
        }
    }
}

