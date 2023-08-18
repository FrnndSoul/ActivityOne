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
        int Failedlogin;
        int LoginAttempt;
        public LoginForm()
        {
            InitializeComponent();
            Password.PasswordChar = '*';
            AcceptButton = SigninButton;
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
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();
            } else if (RegisteredAccounts.ContainsKey(username) && RegisteredAccounts[username] == password)
            {
                    CreateAccount CreateAccount = new CreateAccount();
                    CreateAccount.ShowDialog();
                    this.MinimizeBox = true;
            } else
            {
               
            }
        }
        private void Createbtn_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
            this.Close();
        }
    }
}