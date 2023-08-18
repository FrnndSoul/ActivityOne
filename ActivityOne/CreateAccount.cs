using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ActivityOne
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
            PasswordBox.PasswordChar = '*';
        }
        private void ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            PasswordBox.PasswordChar = ShowPassBox.Checked ? '\0' : '*';
        }

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string username = Username.Text;
            string email = Email.Text;
            string password = PasswordBox.Text;

            // Find the open AdminForm (if it's open)
            AdminForm adminForm = Application.OpenForms.OfType<AdminForm>().FirstOrDefault();

            // Check if the username is already used
            if (adminForm != null && adminForm.IsUsernameTaken(username))
            {
                MessageBox.Show("Username is already taken. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without proceeding further
            }

            if (adminForm != null && adminForm.IsEmailTaken(email))
            {
                MessageBox.Show("Email is used by a different account. Please choose a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without proceeding further
            }

            if (adminForm != null)
            {
                adminForm.AddUserToDataGridView(name, username, email, password);
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}