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
            String username, password;
            username = Username.Text;
            password = Password.Text;
            DataGridViewRow userRow = adminFormInstance.GetUserInfoRowByUsername(username);

            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("ADMIN LOG IN COMPLETE!", "WELCOME BOSS!");
                adminFormInstance.Show();
                Username.Text = "";
                Password.Text = "";
                return;
            }

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please provide both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Username.Text = "";
                Password.Text = "";
                return;
            }

            if (userRow != null)
            {

                string storedPassword = userRow.Cells["tblPassword"].Value.ToString();
                string activationStatus = userRow.Cells["tblActivation"].Value.ToString();
                string tblEmail = userRow.Cells["tblEmail"].Value.ToString();
                string tblUsername = userRow.Cells["tblUsername"].Value.ToString();

                int puk = Convert.ToInt32(userRow.Cells["tblPUK"].Value);
                if (activationStatus != "Activated")
                {
                    MessageBox.Show("Your account is not active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Username.Text = "";
                    Password.Text = "";
                    return;
                }

                if (password == storedPassword)
                {
                    string storedEmail = userRow.Cells["tblEmail"].Value.ToString();
                    string storedUsername = userRow.Cells["tblUsername"].Value.ToString();
                    UserForm userForm = new UserForm();
                    userForm.SetProfile(storedEmail, storedUsername);
                    MessageBox.Show("Login success!", $"WELCOME {storedUsername}!", MessageBoxButtons.OK);
                    Username.Text = "";
                    Password.Text = "";
                    userForm.ShowDialog();
                }
                else
                {
                    puk++;
                    userRow.Cells["tblPUK"].Value = puk;
                    MessageBox.Show($"Incorrect password. You have {3 - puk} attempt(s) remaining.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (puk >= 3)
                    {
                        userRow.Cells["tblActivation"].Value = "Deactivated";
                    }
                }
            }
            else
            {
                DataGridViewRow passRow = adminFormInstance.GetUserInfoRowByPassword(password);

                if (passRow == null)
                {
                    MessageBox.Show("Both username and password incorrect", "ERROR");
                }
                else if (passRow.Cells["tblUsername"].Value.ToString() != username)
                {
                    MessageBox.Show("Password correct, please provide correct username", "ERROR");
                }
            }
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