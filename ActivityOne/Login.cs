using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ActivityOne
{
    public partial class LoginForm : Form
    {
        private AdminForm adminFormInstance;
        private CreateAccount createAccountInstance;
        public LoginForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;

            Password.PasswordChar = '*';
            AcceptButton = SigninButton;

            SigninButton.FlatAppearance.BorderSize = 0;
            Forgotbtn.FlatAppearance.BorderSize = 0;
            Createbtn.FlatAppearance.BorderSize = 0;

            adminFormInstance = new AdminForm();
            createAccountInstance = new CreateAccount();
        }        
        private void Showpass_CheckedChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = Showpass.Checked ? '\0' : '*';
        }
        private void SigninButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            if (username == "admin" && password == "admin123")
            {
                ShowAdminForm();
            }
            /*if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Please provide both username and password.");
                return;
            }
            if (userRow != null)
            {
                string storedPassword = userRow.Cells["tblPassword"].Value.ToString();
                string activationStatus = userRow.Cells["tblActivation"].Value.ToString();

                if (activationStatus != "Activated")
                {
                    ShowErrorMessage("Your account is not active.");
                    return;
                }

                if (password == storedPassword)
                {
                    userRow.Cells["tblPUK"].Value = 0;
                    ShowUserForm(userRow.Cells["tblEmail"].Value.ToString(), userRow.Cells["tblUsername"].Value.ToString(), userRow.Cells["tblName"].Value.ToString());
                }
                else
                {
                    HandleIncorrectPassword(userRow);
                }
            }*/
            else
            {
                DataGridViewRow passRow = adminFormInstance.GetUserInfoRowByPassword(password);

                if (passRow == null)
                {
                    ShowErrorMessage("Account not found!");
                }
                else if (passRow.Cells["tblUsername"].Value.ToString() != username)
                {
                    ShowErrorMessage("Please provide correct username");
                }
            }
        }
        private void ShowAdminForm()
        {
            MessageBox.Show("ADMIN LOG IN COMPLETE!", "WELCOME BOSS!");
            adminFormInstance.Show();
            ClearFields();
        }
        private void ShowCreateAccount()
        {
            createAccountInstance.ShowDialog();
        }
        private void ShowUserForm(string email, string username, string name)
        {
            UserForm userForm = new UserForm();
            userForm.SetProfile(email, username, name);
            MessageBox.Show("Login success!", $"WELCOME {username}!", MessageBoxButtons.OK);
            ClearFields();
            userForm.ShowDialog();
        }
        private void HandleIncorrectPassword(DataGridViewRow userRow)
        {
            int puk = Convert.ToInt32(userRow.Cells["tblPUK"].Value);
            puk++;
            userRow.Cells["tblPUK"].Value = puk;

            if (puk >= 3)
            {
                userRow.Cells["tblActivation"].Value = "Deactivated";
            }
            ShowErrorMessage($"Incorrect password. You have {3 - puk} attempt(s) remaining.");
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearFields();
        }
        private void ClearFields()
        {
            Username.Text = "";
            Password.Text = "";
        }
        private void Createbtn_Click(object sender, EventArgs e)
        {
            ShowCreateAccount();
        }
        private void Forgotbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Have already registered with us?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ForgotPassword forgotPassword = new ForgotPassword();
                forgotPassword.ShowDialog();
            }
        }
    }
}