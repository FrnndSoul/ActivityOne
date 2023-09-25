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
using System.Xml.Linq;
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

                    string checkUsernameQuery = "SELECT ID, Name, Email, Username, Activation, PassHash FROM userlist WHERE Username = @Username";

                    using (MySqlCommand checkUsernameCommand = new MySqlCommand(checkUsernameQuery, connection))
                    {
                        checkUsernameCommand.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = checkUsernameCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string activationStatus = reader["Activation"].ToString();
                                string hashedPasswordFromDB = reader["PassHash"].ToString();
                                string DID = reader["ID"].ToString();
                                string DName = reader["Name"].ToString();
                                string DUsername = reader["Username"].ToString();
                                string DEmail = reader["Email"].ToString();

                                if (string.Equals(activationStatus, "Active", StringComparison.OrdinalIgnoreCase))
                                {
                                    string hashedPassword = HashHelper.HashString(password);

                                    if (hashedPassword == hashedPasswordFromDB)
                                    {
                                        ResetPUK(DUsername);
                                        ShowUserForm(DID, DName, DUsername, DEmail);
                                        ClearFields();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        HandleIncorrectPassword(username);
                                        ClearFields();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Account is not activated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ClearFields();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
            }
        }
        private void ShowAdminForm()
        {
            MessageBox.Show("ADMIN LOG IN COMPLETE!", "WELCOME BOSS!");
            adminFormInstance.Show();
            adminFormInstance.LoadData();
            ClearFields();
        }
        public void refresh()
        {
            adminFormInstance.LoadData();
        }
        private void ShowCreateAccount()
        {
            createAccountInstance.ShowDialog();
        }
        private void ShowUserForm(string id, string name, string username, string email)
        {
            MessageBox.Show("Login success!", "WELCOME", MessageBoxButtons.OK);
            ClearFields();
            UserForm userForm = new UserForm();
            userForm.LoadData(id, name, username, email);
            userForm.ShowDialog();
        }
        private void HandleIncorrectPassword(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    string getAttemptQuery = "SELECT Attempt FROM userlist WHERE Username = @Username";

                    using (MySqlCommand getAttemptCommand = new MySqlCommand(getAttemptQuery, connection))
                    {
                        getAttemptCommand.Parameters.AddWithValue("@Username", username);

                        object attemptObj = getAttemptCommand.ExecuteScalar();
                        int currentAttempt = (attemptObj != null) ? Convert.ToInt32(attemptObj) : 0;

                        currentAttempt++;

                        string updateAttemptQuery = "UPDATE userlist SET Attempt = @Attempt WHERE Username = @Username";

                        using (MySqlCommand updateAttemptCommand = new MySqlCommand(updateAttemptQuery, connection))
                        {
                            updateAttemptCommand.Parameters.AddWithValue("@Attempt", currentAttempt);
                            updateAttemptCommand.Parameters.AddWithValue("@Username", username);

                            updateAttemptCommand.ExecuteNonQuery();
                        }
                        if (currentAttempt >= 3)
                        {
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
        private void ResetPUK(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    string getAttemptQuery = "SELECT Attempt FROM userlist WHERE Username = @Username";

                    using (MySqlCommand getAttemptCommand = new MySqlCommand(getAttemptQuery, connection))
                    {
                        getAttemptCommand.Parameters.AddWithValue("@Username", username);

                        int currentAttempt = 0;

                        string updateAttemptQuery = "UPDATE userlist SET Attempt = @Attempt WHERE Username = @Username";

                        using (MySqlCommand updateAttemptCommand = new MySqlCommand(updateAttemptQuery, connection))
                        {
                            updateAttemptCommand.Parameters.AddWithValue("@Attempt", currentAttempt);
                            updateAttemptCommand.Parameters.AddWithValue("@Username", username);

                            updateAttemptCommand.ExecuteNonQuery();
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
            Showpass.CheckState = CheckState.Unchecked;
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