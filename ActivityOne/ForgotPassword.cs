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
    public partial class ForgotPassword : Form
    {
        private AdminForm AdminInstance;
        public ForgotPassword()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
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

            // Step 1: Check if the input username exists in the DataGridView
            foreach (DataGridViewRow row in AdminInstance.UserInfoDataGridView.Rows)
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
        }    }
}
