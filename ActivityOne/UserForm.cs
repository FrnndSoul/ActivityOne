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
using MySql.Data.MySqlClient;

namespace ActivityOne
{
    public partial class UserForm : Form       
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserUsername { get; set; }
        public string UserEmail { get; set; }
        public UserForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Load += UserForm_Load;
        }
        private void SignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            idBox.Text = UserID;
            nameBox.Text = UserName;
            usernameBox.Text = UserUsername;
            emailBox.Text = UserEmail;
        }
    }
}