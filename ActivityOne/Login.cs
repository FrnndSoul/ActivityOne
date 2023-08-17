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
        private int failedLoginAttempts = 0;
        private const int maxFailedAttempts = 3; // Maximum allowed failed attempts\
        private Dictionary<string, CreateAccount.Account> registeredAccounts = new Dictionary<string, CreateAccount.Account>();
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
            string enteredUsername = Username.Text;
            string enteredPassword = Password.Text;

            if (registeredAccounts.ContainsKey(enteredUsername))
            {
                CreateAccount.Account account = registeredAccounts[enteredUsername];

                if (account.Password == enteredPassword)
                {
                    MessageBox.Show($"Logged in successfully as {enteredUsername}.");
                    failedLoginAttempts = 0;
                }
                else
                {
                    failedLoginAttempts++;
                    int attemptsLeft = maxFailedAttempts - failedLoginAttempts;

                    if (attemptsLeft > 0)
                    {
                        MessageBox.Show($"Invalid login for {enteredUsername}. {attemptsLeft} attempts left.");
                    }
                    else
                    {
                        failedLoginAttempts = maxFailedAttempts;
                        MessageBox.Show("Account is now locked due to too many failed attempts. Please contact support.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username.");
            }

            Username.Text = "";
            Password.Text = "";
        }

        private bool IsAccountLocked()
        {
            return failedLoginAttempts >= maxFailedAttempts;
        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            CreateAccount CreateAccount = new CreateAccount();
            CreateAccount.ShowDialog();

            registeredAccounts = CreateAccount.GetRegisteredAccounts();
        }
    }
}