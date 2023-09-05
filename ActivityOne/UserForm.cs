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
    public partial class UserForm : Form
    {
        private string tblUsername;
        private string tblEmail;
        private string tblName;
        public UserForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void SetProfile(string email, string username, string name)
        {
            tblEmail = email;
            tblUsername = username;
            tblName = name;
            emailBox.Text = tblEmail;
            usernameBox.Text = tblUsername;
            nameBox.Text = tblName;
        }
        private void SignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}