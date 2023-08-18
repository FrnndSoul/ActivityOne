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

            AdminForm adminForm = Application.OpenForms.OfType<AdminForm>().FirstOrDefault();

            if (adminForm != null)
            {
                adminForm.AddUserToDataGridView(name, username, email, password);
            }

        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}