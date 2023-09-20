using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ActivityOne
{
    public partial class LoginForm : Form
    {
        public class HashHelper
        {
            public static string HashString(string input)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                    byte[] hashBytes = sha256.ComputeHash(inputBytes);

                    string hashedString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    return hashedString;
                }
            }
        }

        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        public MySqlConnection connection = new MySqlConnection(mysqlcon);

        private AdminForm adminFormInstance;
        private CreateAccount createAccountInstance;
        public LoginForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;

            Password.PasswordChar = '*';
            AcceptButton = SigninButton;

            SigninButton.FlatAppearance.BorderSize = 0;
            Forgotbtn.FlatAppearance.BorderSize = 0;
            Createbtn.FlatAppearance.BorderSize = 0;

            adminFormInstance = new AdminForm();
            createAccountInstance = new CreateAccount();
        }        
        private void Showpass_CheckedChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = Showpass.Checked ? '\0' : '*';
        }
        private void SigninButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            if (username == "admin" && password == "admin123")
            {
                ShowAdminForm();
                return;
            }
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Please provide both username and password.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    // Check if the username exists in the database
                    string checkUsernameQuery = "SELECT Activation, PassHash FROM userlist WHERE Username = @Username";

                    using (MySqlCommand checkUsernameCommand = new MySqlCommand(checkUsernameQuery, connection))
                    {
                        checkUsernameCommand.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = checkUsernameCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string activationStatus = reader["Activation"].ToString();
                                string hashedPasswordFromDB = reader["PassHash"].ToString();

                                if (activationStatus == "Activated")
                                {
                                    string hashedPassword = HashHelper.HashString(password);

                                    if (hashedPassword == hashedPasswordFromDB)
                                    {
                                        MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //HandleIncorrectPassword();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Account is not activated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            /*if (userRow != null)
            {
                string storedPassword = userRow.Cells["tblPassword"].Value.ToString();
                string activationStatus = userRow.Cells["tblActivation"].Value.ToString();

                if (activationStatus != "Activated")
                {
                    ShowErrorMessage("Your account is not active.");
                    return;
                }

                if (password == storedPassword)
                {
                    userRow.Cells["tblPUK"].Value = 0;
                    ShowUserForm(userRow.Cells["tblEmail"].Value.ToString(), userRow.Cells["tblUsername"].Value.ToString(), userRow.Cells["tblName"].Value.ToString());
                }
                else
                {
                    HandleIncorrectPassword(userRow);
                }
            }
            else
            {
                DataGridViewRow passRow = adminFormInstance.GetUserInfoRowByPassword(password);

                if (passRow == null)
                {
                    ShowErrorMessage("Account not found!");
                }
                else if (passRow.Cells["tblUsername"].Value.ToString() != username)
                {
                    ShowErrorMessage("Please provide correct username");
                }
            }*/
        }
        private void ShowAdminForm()
        {
            MessageBox.Show("ADMIN LOG IN COMPLETE!", "WELCOME BOSS!");
            adminFormInstance.Show();
            ClearFields();
        }
        private void ShowCreateAccount()
        {
            createAccountInstance.ShowDialog();
        }
        private void ShowUserForm(string email, string username, string name)
        {
            //get userinfo in database
            MessageBox.Show("Login success!", $"WELCOME {username}!", MessageBoxButtons.OK);
            ClearFields();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }
        private void HandleIncorrectPassword(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    // Get the current 'Attempt' value from the database
                    string getAttemptQuery = "SELECT Attempt FROM userlist WHERE Username = @Username";

                    using (MySqlCommand getAttemptCommand = new MySqlCommand(getAttemptQuery, connection))
                    {
                        getAttemptCommand.Parameters.AddWithValue("@Username", username);

                        object attemptObj = getAttemptCommand.ExecuteScalar();
                        int currentAttempt = (attemptObj != null) ? Convert.ToInt32(attemptObj) : 0;

                        // Increment the 'Attempt' value
                        currentAttempt++;

                        // Update the 'Attempt' value in the database
                        string updateAttemptQuery = "UPDATE userlist SET Attempt = @Attempt WHERE Username = @Username";

                        using (MySqlCommand updateAttemptCommand = new MySqlCommand(updateAttemptQuery, connection))
                        {
                            updateAttemptCommand.Parameters.AddWithValue("@Attempt", currentAttempt);
                            updateAttemptCommand.Parameters.AddWithValue("@Username", username);

                            updateAttemptCommand.ExecuteNonQuery();
                        }

                        // Check if the user has exceeded the maximum number of attempts (e.g., 3)
                        if (currentAttempt >= 3)
                        {
                            // Lock the account (you should implement this logic)
                            LockAccount(username);
                            MessageBox.Show("Account locked due to too many incorrect login attempts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Incorrect password attempt {currentAttempt} out of 3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockAccount(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    // Update the 'Activation' status to 'Locked' in the database
                    string lockAccountQuery = "UPDATE userlist SET Activation = 'Locked' WHERE Username = @Username";

                    using (MySqlCommand lockAccountCommand = new MySqlCommand(lockAccountQuery, connection))
                    {
                        lockAccountCommand.Parameters.AddWithValue("@Username", username);

                        lockAccountCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearFields();
        }
        private void ClearFields()
        {
            Username.Text = "";
            Password.Text = "";
        }
        private void Createbtn_Click(object sender, EventArgs e)
        {
            ShowCreateAccount();
        }
        private void Forgotbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Have already registered with us?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ForgotPassword forgotPassword = new ForgotPassword();
                forgotPassword.ShowDialog();
            }
        }
    }
}