﻿using System;
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

                if (activationStatus != "Activated")
                {
                    MessageBox.Show("Your account is not active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Username.Text = "";
                    Email.Text = "";
                    return;
                }

                if (inputEmail == storedEmail)
                {
                    string storedPassword = userRow.Cells["tblPassword"].Value.ToString();
                    MessageBox.Show("Email was sent to your registered email address. \n" +
                        "You can now close this window", "EMAIL SENT",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Email email = new Email();
                    email.SetPassword(storedPassword); // Set the password using the method
                    email.ShowDialog();

                    Username.Text = "";
                    Email.Text = "";
                    Close();
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
        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
