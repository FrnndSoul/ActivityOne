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

namespace ActivityOne
{
    public partial class ForgotPassword : Form
    {
        private AdminForm adminFormInstance;
        public ForgotPassword()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            AcceptButton = Forgot;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Text_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Forgot_Click(object sender, EventArgs e)
        {
            string inputUsername = Username.Text;
            string inputEmail = Email.Text;

            bool foundUser = false;
            bool foundEmail = false;
            string foundPassword = null;

            AdminForm adminFormInstance = Application.OpenForms.OfType<AdminForm>().FirstOrDefault();
            DataGridViewRow userRow = adminFormInstance.GetUserInfoRowByUsername(inputUsername);
            
            if (string.IsNullOrEmpty(inputUsername) || string.IsNullOrEmpty(inputEmail))
            {
                MessageBox.Show("Please provide both username and email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Username.Text = "";
                Email.Text = "";
                return;
            }

            if (userRow != null)
            {
                string storedEmail = userRow.Cells["tblEmail"].Value.ToString();
                string activationStatus = userRow.Cells["tblActivation"].Value.ToString();
                string storedPassword = userRow.Cells["tblPassword"].Value.ToString();

                if (activationStatus != "Activated")
                {
                    MessageBox.Show("Your account is not active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Username.Text = "";
                    Email.Text = "";
                    return;
                }

                if (inputEmail == storedEmail)
                {

                    MessageBox.Show($"Good day {inputUsername}, \n \nIt seems that you've forgotten" +
                        $" your password. \nYour password is: {storedPassword}\n \nPlease do not forget it again!", "Password Retrieval");
                    Username.Text = "";
                    Email.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show("please enter correct account info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please enter correct account info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Username.Text = "";
            Email.Text = "";
        }






/*
            // Step 1: Check if the input username exists in the DataGridView
            foreach (DataGridViewRow row in adminFormInstance.UserInfoDataGridView.Rows)
            {
                if (row.Cells["tblUsername"].Value != null && row.Cells["tblUsername"].Value.ToString() == inputUsername)
                {
                    foundUser = true;

                    // Step 2: Check if the input email matches the user's email
                    if (row.Cells["tblEmail"].Value.ToString() == inputEmail)
                    {
                        foundEmail = true;
                        foundPassword = row.Cells["tblPassword"].Value.ToString();
                        break;
                    }
                }
            }

            if (foundUser)
            {
                if (foundEmail)
                {
                    // Step 3: Display the user's password
                    MessageBox.Show($"Your password is: {foundPassword}", "Password Retrieval");
                }
                else
                {
                    // Step 5: Email is correct, but username is incorrect
                    MessageBox.Show("Incorrect username. Email is correct.", "Error");
                }
            }
            else
            {
                // Step 4: Email and username do not match any records
                MessageBox.Show("No matching records found.", "Error");
            }
        }
        */
        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
