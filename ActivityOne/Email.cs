﻿using System;
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
    public partial class Email : Form
    {
        private string userPassword;
        private string userUsername; 
        public Email()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void SetCredentials(string username, string password)
        {
            userPassword = password;
            userUsername = username;
            usernameBox.Text = $" {username},";
            passwordBox.Text = $" {password}";
            Title.Text = DateTime.Now.ToString("MMMM dd ,yyyy HH:mm:ss");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("have you taken note of your password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        private void Display_TextChanged(object sender, EventArgs e)
        {

        }
        private void Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}