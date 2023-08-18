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
    public partial class AdminForm : Form
    {
        String Name, Username, Email, Password, Activation, PUK;
        public AdminForm()
        {
            InitializeComponent();
            UserInfo.Rows.Add(Name, Username, Email, Password, Activation, PUK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        public void AddUserToDataGridView(string name, string username, string email, string password)
        {
            UserInfo.Rows.Add(name, username, email, password, "Locked", "0");
        }

        private void Activate_Click(object sender, EventArgs e)
        {
            if (UserInfo.SelectedRows.Count != 0)
            {
                DataGridViewRow selectedRow = UserInfo.SelectedRows[0];
                int statusColumnIndex = UserInfo.Columns["tblActivation"].Index;

                string currentStatus = selectedRow.Cells[statusColumnIndex].Value.ToString();

                if (currentStatus == "Activated")
                {
                    MessageBox.Show("User profile is already activated!");
                }
                else
                {
                    if (currentStatus == "Locked")
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to activate this account?", "Confirm Activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            selectedRow.Cells[statusColumnIndex].Value = "Activated";
                            MessageBox.Show("Account activated!");
                        }
                    } else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to reactivate this account?", "Confirm Reactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            selectedRow.Cells[statusColumnIndex].Value = "Activated";
                            MessageBox.Show("Account reactivated!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No data selected!");
            }
        }

        public bool IsUsernameTaken(string username)
        {
            // Assuming you have a DataGridView named UserInfo on AdminForm
            foreach (DataGridViewRow row in UserInfo.Rows)
            {
                if (row.Cells["tblUsername"].Value != null && row.Cells["tblUsername"].Value.ToString() == username)
                {
                    return true; // Username is taken
                }
            }
            return false; // Username is not taken
        }

        public bool IsEmailTaken(string email)
        {
            // Assuming you have a DataGridView named UserInfo on AdminForm
            foreach (DataGridViewRow row in UserInfo.Rows)
            {
                if (row.Cells["tblEmail"].Value != null && row.Cells["tblEmail"].Value.ToString() == email)
                {
                    return true; // Username is taken
                }
            }
            return false; // Username is not taken
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Activatebtn_Click(object sender, EventArgs e)
        {
            if (UserInfo.SelectedRows.Count != 0)
            {
                DataGridViewRow selectedRow = UserInfo.SelectedRows[0];
                selectedRow.Cells["tblActivation"].Value = "Activated";
            }
            else
            {
                MessageBox.Show("Please select a row to activate.");
            }
        }

        public void DeleteFirstRow()
        {
            UserInfo.Rows.RemoveAt(0);
        }

        public DataGridViewRow GetUserInfoRowByUsername(string username)
        {
            foreach (DataGridViewRow row in UserInfo.Rows)
            {
                if (row.Cells["tblUsername"].Value != null && row.Cells["tblUsername"].Value.ToString() == username)
                {
                    return row; // Found the user's row
                }
            }
            return null; // User not found
        }



    }
}
