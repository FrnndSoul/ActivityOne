using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ActivityOne
{
    public partial class LoginForm : Form
    {
        private Dictionary<string, string> RegisteredAccounts = new Dictionary<string, string>();
        private AdminForm adminFormInstance;
        
        public LoginForm()
        {
            InitializeComponent();
            Password.PasswordChar = '*';
            AcceptButton = SigninButton;

            if (adminFormInstance == null || adminFormInstance.IsDisposed)
            {
                adminFormInstance = new AdminForm();
            }

            adminFormInstance.Show();
            adminFormInstance.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
        private void Showpass_CheckedChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = Showpass.Checked ? '\0' : '*';
        }
        private void SigninButton_Click(object sender, EventArgs e)
        {
            String username, password;
            username = Username.Text;
            password = Password.Text;  

            if (username == "admin" && password == "admin123")
            {
                if (adminFormInstance == null || adminFormInstance.IsDisposed)
                {
                    adminFormInstance = new AdminForm();
                }

                // Show the adminFormInstance
                adminFormInstance.Show();

                Username.Text = "";
                Password.Text = "";
            } else if (RegisteredAccounts.ContainsKey(username) && RegisteredAccounts[username] == password)
            {
                this.MinimizeBox = true;
                Username.Text = "";
                Password.Text = "";
            } else
            {
               
            }
        }
        private void Createbtn_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
        }
    }
}