using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ActivityOne
{
    public partial class Email : Form
    {
        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        public MySqlConnection connection = new MySqlConnection(mysqlcon);

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
        public class HashHelper_Salt
        {
            public static string HashString_Salt(string input_Salt)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputBytes_Salt = Encoding.UTF8.GetBytes(input_Salt);

                    byte[] hashBytes_Salt = sha256.ComputeHash(inputBytes_Salt);

                    string hashedString_Salt = BitConverter.ToString(hashBytes_Salt).Replace("-", "").ToLower();

                    return hashedString_Salt;
                }
            }
        }
        public class HashHelper_SaltperUser
        {
            public static string HashString_SaltperUser(string input_SaltperUser)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] inputBytes_SaltperUser = Encoding.UTF8.GetBytes(input_SaltperUser);

                    byte[] hashBytes_SaltperUser = sha256.ComputeHash(inputBytes_SaltperUser);

                    string hashedString_SaltperUser = BitConverter.ToString(hashBytes_SaltperUser).Replace("-", "").ToLower();

                    return hashedString_SaltperUser;
                }
            }
        }

        public Email()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void SetUsername(string username, string email, string ID)
        {
            usernameBox.Text = username;
        }
        private void Set_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (!IsPasswordValid(password))
            {
                MessageBox.Show("Password must have at least 8 characters, \nwith uppercase and lowercase letters, \nand at least one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();

                    string getID = "SELECT ID FROM userlist WHERE Username = @Username";

                    using (MySqlCommand checkIDcmd = new MySqlCommand(getID, connection))
                    {
                        checkIDcmd.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = checkIDcmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string ID = reader["ID"].ToString();
                                reader.Close(); // Close the reader before executing the next query

                                string hashedPassword = HashHelper.HashString(password);
                                string fixedSalt = HashHelper_Salt.HashString_Salt("420" + password + "69");
                                string perUserSalt = HashHelper_SaltperUser.HashString_SaltperUser(password + ID);

                                string setPass = "UPDATE `userlist` " +
                                    "SET `PassHash` = @hashedPassword, `SaltHash` = @fixedSalt, `UserSalt` = @perUserSalt " +
                                    "WHERE Username = @username;";

                                using (MySqlCommand setPasscmd = new MySqlCommand(setPass, connection))
                                {
                                    setPasscmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                                    setPasscmd.Parameters.AddWithValue("@fixedSalt", fixedSalt);
                                    setPasscmd.Parameters.AddWithValue("@perUserSalt", perUserSalt);
                                    setPasscmd.Parameters.AddWithValue("@username", username);

                                    int rowsAffected = setPasscmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Password updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Password update failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            finally
            {
                this.Close();
            }
        }
        private void Back_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasSpecialCharacter = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUppercase = true;
                else if (char.IsLower(c))
                    hasLowercase = true;
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                    hasSpecialCharacter = true;
            }
            return hasUppercase && hasLowercase && hasSpecialCharacter;
        }
    }
}