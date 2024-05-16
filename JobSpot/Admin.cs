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

namespace JobSpot
{
    public partial class Admin : Form
    {
        public static DataTable userinfotable()
        {

            SqlConnection con = new SqlConnection(@"Data Source=Mahi\SQLEXPRESS01;Initial Catalog=JobSpot1DB;Integrated Security=True;Encrypt=False;");

            string query = "SELECT [Email], [Full_Name], [National_ID], [Phone_Number] FROM [JobSpot1DB].[dbo].[SignUp]";


            DataTable table = new DataTable();


            table.Columns.Add("Email");
            table.Columns.Add("Full_Name");
            table.Columns.Add("National_ID");
            table.Columns.Add("Phone_Number");


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

            result.Fill(table);


            table.Columns.Add("Delete");

            foreach (DataRow row in table.Rows)
            {
                row["Delete"] = "Delete";
            }

            return table;
        }
        public Admin()
        {
            InitializeComponent();
            userinfo.DataSource = userinfotable();
            userinfo.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userinfo.Columns["Full_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            userinfo.Columns["National_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            userinfo.Columns["Phone_Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            userinfo.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
