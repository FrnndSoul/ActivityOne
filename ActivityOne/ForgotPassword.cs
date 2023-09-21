using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;

namespace ActivityOne
{
    public partial class ForgotPassword : Form
    {
        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        MySqlConnection connection = new MySqlConnection(mysqlcon);

        private AdminForm adminFormInstance;
        public ForgotPassword()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AcceptButton = Forgot;
        }
        private void Forgot_Click(object sender, EventArgs e)
        {
            string inputUsername = Username.Text;
            string inputEmail = Email.Text;

            //checks if username exist in the database
            //checks if the email exists in the database
            //checks if username and email matches a single user in the database
            //prompt to change the password

            Username.Text = "";
            Email.Text = "";
        }
        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}