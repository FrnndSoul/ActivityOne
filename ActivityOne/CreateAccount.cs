using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ActivityOne
{
    public partial class CreateAccount : Form
    {
        public class Account
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        

        private Dictionary<string, Account> registeredAccounts = new Dictionary<string, Account>();

        public CreateAccount()
        {
            InitializeComponent();
            Passwordbox.PasswordChar = '*';
        }
        private void ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            Passwordbox.PasswordChar = ShowPassBox.Checked ? '\0' : '*';
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            // Create a new account instance
            Account newAccount = new Account
            {
                Name = Name.Text,
                Username = Username.Text,
                Email = Email.Text,
                Password = Passwordbox.Text
            };

            // Add the account to the dictionary using the username as the key
            registeredAccounts[newAccount.Username] = newAccount;

            MessageBox.Show("Account registered successfully!");

            // Clear the fields after registration
            Name.Text = "";
            Username.Text = "";
            Email.Text = "";
            Passwordbox.Text = "";
        }

        public Dictionary<string, Account> GetRegisteredAccounts()
        {
            return registeredAccounts;
        }
        
    }
}
