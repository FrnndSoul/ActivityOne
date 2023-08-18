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
    public partial class AdminForm : Form
    {
        String Name, Username, Email, Password, Activation;
        public AdminForm()
        {
            InitializeComponent();
            UserInfo.Rows.Add(Name, Username, Email, Password, Activation);
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
            UserInfo.Rows.Add(name, username, email, password, "Deactivated", "0");
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
    }
}
