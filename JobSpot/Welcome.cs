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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            SelectType selectTypeForm = new SelectType();

            selectTypeForm.Show();

            this.Hide();
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            AdminLogin adminLoginForm = new AdminLogin();

            adminLoginForm.Show();
        }
    }
}
