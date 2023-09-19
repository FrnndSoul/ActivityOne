using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ActivityOne
{
    public partial class AdminForm : Form
    {
        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        public MySqlConnection connection = new MySqlConnection(mysqlcon);

        public AdminForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AcceptButton = Activate;
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
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                connection.Open();

                string sql = "SELECT * FROM `userlist`";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                System.Data.DataTable dataTable = new System.Data.DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
                UserInfo.DataSource = dataTable;
                UserInfo.Columns[0].Visible = false;
                UserInfo.Columns[4].Visible = false;
                UserInfo.Columns[6].Visible = false;
                UserInfo.Columns[7].Visible = false;
                UserInfo.Columns[8].Visible = false;
                UserInfo.Columns[9].Visible = false;
                UserInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void Activate_Click(object sender, EventArgs e)
        {
            if (UserInfo.SelectedRows.Count != 0)
            {
                DataGridViewRow selectedRow = UserInfo.SelectedRows[0];
                int statusColumnIndex = UserInfo.Columns["tblActivation"].Index;
                int pukColumnIndex = UserInfo.Columns["tblPUK"].Index;

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
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to reactivate this account?", "Confirm Reactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            selectedRow.Cells[statusColumnIndex].Value = "Activated";
                            selectedRow.Cells[pukColumnIndex].Value = "0";
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
            foreach (DataGridViewRow row in UserInfo.Rows)
            {
                if (row.Cells["tblUsername"].Value != null && row.Cells["tblUsername"].Value.ToString() == username)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsEmailTaken(string email)
        {
            foreach (DataGridViewRow row in UserInfo.Rows)
            {
                if (row.Cells["tblEmail"].Value != null && row.Cells["tblEmail"].Value.ToString() == email)
                {
                    return true;
                }
            }
            return false;
        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
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
                    return row;
                }
            }
            return null;
        }
        public DataGridViewRow GetUserInfoRowByPassword(string password)
        {
            foreach (DataGridViewRow row in UserInfo.Rows)
            {
                if (row.Cells["tblPassword"].Value != null && row.Cells["tblPassword"].Value.ToString() == password)
                {
                    return row;
                }
            }
            return null;
        }
    }
}