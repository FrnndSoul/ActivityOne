﻿using System;
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            PasswordBox.PasswordChar = '*';
            ShowPassBox.CheckedChanged += ShowPass_CheckedChanged;
            AcceptButton = Registerbtn;
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

            if (username == "admin" || username == "Admin")
            {
                MessageBox.Show("Cannot register with admin as a username","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            string maskedPassword = password.Length >= 4
                ? password.Substring(0, 2) + new string('*', password.Length - 4) + password.Substring(password.Length - 2)
    :           new string('*', password.Length);

            DialogResult result = MessageBox.Show("Do you want to register with these information?!" +
                $"\n\nName: {name}" +
                $"\nUsername: {username}" +
                $"\nEmail: {email}" +
                $"\nPassword: {maskedPassword}" +
                $"\n\nChanges on the account cannot be done!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsPasswordValid(password))
            {
                MessageBox.Show("Password must have at least 8 characters, \nwith uppercase and lowercase letters, \nand at least one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                //hash the password
                //general salt the hash
                //salt per user on the hashed password
                //add to DB
                MessageBox.Show("Registration is awaiting approval, hang tight!");
                this.Close();
                Close();
        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true; // Suppress the key press
            }
        }
        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasSpecialCharacter = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUppercase = true;
                else if (char.IsLower(c))
                    hasLowercase = true;
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                    hasSpecialCharacter = true;
            }

            return hasUppercase && hasLowercase && hasSpecialCharacter;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}