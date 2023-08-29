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
            adminFormInstance.Show();
            adminFormInstance.DeleteFirstRow();
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
            string username = Username.Text;
            string password = Password.Text;
            DataGridViewRow userRow = adminFormInstance.GetUserInfoRowByUsername(username);

            if (username == "admin" && password == "admin123")
            {
                ShowAdminForm();
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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
                    ShowUserForm(userRow.Cells["tblEmail"].Value.ToString(), userRow.Cells["tblUsername"].Value.ToString());
                }
                else
                {
                    HandleIncorrectPassword(userRow);
                }
            }
            else
            {
                DataGridViewRow passRow = adminFormInstance.GetUserInfoRowByPassword(password);

                if (passRow == null)
                {
                    ShowErrorMessage("Account not found!");
                }
                else if (passRow.Cells["tblUsername"].Value.ToString() != username)
                {
                    ShowErrorMessage("Password correct, please provide correct username");
                }
            }
        }
        private void ShowAdminForm()
        {
            MessageBox.Show("ADMIN LOG IN COMPLETE!", "WELCOME BOSS!");
            adminFormInstance.Show();
            ClearFields();
        }
        private void ShowUserForm(string email, string username)
        {
            UserForm userForm = new UserForm();
            userForm.SetProfile(email, username);
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
            CreateAccount createAccount = Application.OpenForms.OfType<CreateAccount>().FirstOrDefault();

            if (createAccount == null || createAccount.IsDisposed)
            {
                DialogResult result = MessageBox.Show("Do you want to sign up?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    createAccount = new CreateAccount();
                    createAccount.ShowDialog();
                }
            }
            else
            {
                createAccount.BringToFront();
            }
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