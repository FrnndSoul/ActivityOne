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
                UserInfo.Columns[6].Visible = false; //hashedpass
                UserInfo.Columns[7].Visible = false; //fixedsalt
                UserInfo.Columns[8].Visible = false; //perusersalt
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
            int selectedRowIndex = UserInfo.SelectedCells[0].RowIndex;
            if (selectedRowIndex >= 0 && selectedRowIndex < UserInfo.Rows.Count)
            {
                string selectedUsername = UserInfo.Rows[selectedRowIndex].Cells["Username"].Value.ToString();
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                    {
                        connection.Open();
                        string checkUsernameQuery = "SELECT Activation FROM userlist WHERE Username = @Username";
                        using (MySqlCommand checkUsernameCommand = new MySqlCommand(checkUsernameQuery, connection))
                        {
                            checkUsernameCommand.Parameters.AddWithValue("@Username", selectedUsername);
                            object activationStatusObj = checkUsernameCommand.ExecuteScalar();
                            string activationStatus = (activationStatusObj != null) ? activationStatusObj.ToString() : "";
                            if (activationStatus == "Active")
                            {
                                MessageBox.Show("Account is already activated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                string activateAccountQuery = "UPDATE userlist SET Activation = 'Active' WHERE Username = @Username";
                                using (MySqlCommand activateAccountCommand = new MySqlCommand(activateAccountQuery, connection))
                                {
                                    activateAccountCommand.Parameters.AddWithValue("@Username", selectedUsername);
                                    int rowsAffected = activateAccountCommand.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Account has been successfully activated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Account activation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a valid row to activate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}