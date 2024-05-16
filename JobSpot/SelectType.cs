using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobSpot
{
    public partial class SelectType : Form
    {
        public SelectType()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            // Create an instance of the LoginForm form
            LoginForm loginForm = new LoginForm();

            // Show the LoginForm form
            loginForm.Show();

            // Close the SelectType form
            this.Close();
        }

        private void btnback1_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            welcomeForm.Show();
            this.Close();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Close();
        }
    }
}
