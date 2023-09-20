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
    public partial class UserForm : Form       
    {
        public UserForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void SignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        public void LoadData(string DID, string DName, string DUsername, string DEmail)
        {
            //MessageBox.Show($"ID: {DID}, Name: {DName}, Username: {DUsername}, Email: {DEmail} "); this works
            //but the ones below do not work
            try
            {
                idBox.Text = DID;
                nameBox.Text = DName;
                usernameBox.Text = DUsername;
                emailBox.Text = DEmail;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}