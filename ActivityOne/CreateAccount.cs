using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
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
public class RandomNumberGenerator
{
    private static Random random = new Random();

    public static string GenerateRandomNumber()
    {
        var digits = Enumerable.Range(0, 10).ToList();

        for (int i = 0; i < digits.Count; i++)
        {
            int j = random.Next(i, digits.Count);
            int temp = digits[i];
            digits[i] = digits[j];
            digits[j] = temp;
        }
        string randomNumber = string.Join("", digits.Take(4));

        return randomNumber;
    }
}

namespace ActivityOne
{
    public partial class CreateAccount : Form
    {
        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        public MySqlConnection connection = new MySqlConnection(mysqlcon);
        public CreateAccount()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            PasswordBox.PasswordChar = '*';
            ShowPassBox.CheckedChanged += ShowPass_CheckedChanged;
            AcceptButton = Registerbtn;
        }
        private void ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            PasswordBox.PasswordChar = ShowPassBox.Checked ? '\0' : '*';
        }
        private void Registerbtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string username = Username.Text;
            string email = Email.Text;
            string password = PasswordBox.Text;
            if (username == "admin" || username == "Admin")
            {
                MessageBox.Show("Cannot register with admin as a username","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            string maskedPassword = password.Length >= 4
                ? password.Substring(0, 2) + new string('*', password.Length - 4) + password.Substring(password.Length - 2)
    :           new string('*', password.Length);
            DialogResult result = MessageBox.Show("Do you want to register with these information?!" +
                $"\n\nName: {name}" +
                $"\nUsername: {username}" +
                $"\nEmail: {email}" +
                $"\nPassword: {maskedPassword}" +
                $"\n\nChanges on the account cannot be done!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsPasswordValid(password))
            {
                MessageBox.Show("Password must have at least 8 characters, \nwith uppercase and lowercase letters, \nand at least one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ID = RandomNumberGenerator.GenerateRandomNumber();   //generated ID number
            string hashedPassword = HashHelper.HashString(password);    //Emilp0g!
            string fixedSalt = HashHelper_Salt.HashString_Salt("420" + password + "69");    //420Emilp0g!69
            string perUserSalt = HashHelper_SaltperUser.HashString_SaltperUser(password + ID);    //Emip0g!1999
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mysqlcon))
                {
                    connection.Open();
                    string query = "INSERT INTO `userlist`(`ID`, `Name`, `Email`, `Username`, `Activation`, `Attempt`, `PassHash`, `SaltHash`, `UserSalt`)" +
                                   "VALUES (@ID, @Name, @Email, @Username, 'Inactive', 0, @PassHash, @SaltHash, @UserSalt)";
                    using (MySqlCommand execute = new MySqlCommand(query, connection))
                    {
                        execute.Parameters.AddWithValue("@ID", ID);
                        execute.Parameters.AddWithValue("@Name", name);
                        execute.Parameters.AddWithValue("@Email", email);
                        execute.Parameters.AddWithValue("@Username", username);
                        execute.Parameters.AddWithValue("@PassHash", hashedPassword);
                        execute.Parameters.AddWithValue("@SaltHash", fixedSalt);
                        execute.Parameters.AddWithValue("@UserSalt", perUserSalt);
                        execute.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Awaiting admin approval. \nID number:{ID}", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
            finally
            {
                connection.Close();
            }
            Name.Text = "";
            Username.Text = "";
            Email.Text = "";
            PasswordBox.Text = "";
            this.Close();
        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        private void Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
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