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
            UserInfo.Rows.Add(name, username, email, password, "Activated");
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
