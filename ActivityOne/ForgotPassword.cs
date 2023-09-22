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
    public partial class ForgotPassword : Form
    {
        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        MySqlConnection connection = new MySqlConnection(mysqlcon);

        private AdminForm adminFormInstance;
        public ForgotPassword()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AcceptButton = Forgot;
        }
        private void Forgot_Click(object sender, EventArgs e)
        {
            string inputUsername = Username.Text;
            string inputEmail = Email.Text;
            

            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    string query = "SELECT Username, Email, ID FROM userlist WHERE Username = @Username AND Email = @Email";

                    using (MySqlCommand checkUserCommand = new MySqlCommand(query, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@Username", inputUsername);
                        checkUserCommand.Parameters.AddWithValue("@Email", inputEmail);

                        using (MySqlDataReader reader = checkUserCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string dataID = reader["ID"].ToString();
                                MessageBox.Show($"Password reset for {inputUsername}, {inputEmail}, {dataID}");
                                Email email = new Email();
                                email.Show();
                                email.SetUsername(inputUsername, inputEmail, dataID);
                            }
                            else
                            {
                                MessageBox.Show("Username and email not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            Username.Text = "";
            Email.Text = "";
        }
        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}