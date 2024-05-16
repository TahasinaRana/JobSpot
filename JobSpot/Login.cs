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
    public partial class Login : Form
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=Mahi\SQLEXPRESS01;Initial Catalog=JobSpot1DB;Integrated Security=True;Encrypt=False;");


        public Login()
        {
            InitializeComponent();
            string query = "INSERT INTO [JobSpot1DB].[dbo].[Login] ([Username],[Password]) VALUES('ASD', 'ASD')";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
