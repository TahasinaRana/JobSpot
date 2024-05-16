using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JobSpot
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
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
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (IsValidEmail(email))
            {
                txtEmail.BackColor = Color.White;
            }
            else
            {
                txtEmail.BackColor = Color.LightPink;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txtFull_TextChanged(object sender, EventArgs e)
        {
            string fullName = txtFull.Text.Trim();

            if (IsValidFullName(fullName))
            {
                txtFull.BackColor = Color.White;
            }
            else
            {
                txtFull.BackColor = Color.LightPink;
            }
        }

        private bool IsValidFullName(string fullName)
        {
            string fullNamePattern = @"^[a-zA-Z]+(?:\s[a-zA-Z]+)*$";
            return Regex.IsMatch(fullName, fullNamePattern);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string nationalID = txtID.Text.Trim();

            if (IsValidNationalID(nationalID))
            {
                txtID.BackColor = Color.White;
            }
            else
            {
                txtID.BackColor = Color.LightPink;
            }
        }

        private bool IsValidNationalID(string nationalID)
        {
            string nationalIDPattern = @"^\d{13}$"; 
            return Regex.IsMatch(nationalID, nationalIDPattern);
        }

        private void txtPassw_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassw.Text;

            if (IsValidPassword(password))
            {
                txtPassw.BackColor = Color.White;
            }
            else
            {
                txtPassw.BackColor = Color.LightPink;
            }
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 8;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            string phoneNumber = txtNum.Text.Trim();

            if (IsValidPhoneNumber(phoneNumber))
            {
                txtNum.BackColor = Color.White;
            }
            else
            {
                txtNum.BackColor = Color.LightPink;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phoneNumberPattern = @"^(?:\+?88)?01[3-9]\d{8}$"; 
            return Regex.IsMatch(phoneNumber, phoneNumberPattern);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectType selectTypeForm = new SelectType();

            selectTypeForm.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qry = $"Insert into   [JobSpot1DB].[dbo].[SignUp] ( [Email],[Full_Name],[National_ID] ,[Phone_Number],[Password]) values ('{txtEmail.Text}', '{txtFull.Text}', '{txtID.Text}', '{txtNum.Text}', '{txtPassw.Text}')";
            if (executeQuery2(qry)) {
                this.Close();

                Home homeForm = new Home();

                homeForm.Show();
            }
            else
            {
                MessageBox.Show("Sign Up Not Successful");
            }
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
            SelectType selectTypeForm = new SelectType();

            selectTypeForm.Show();

            this.Close();
        }
    }
}
