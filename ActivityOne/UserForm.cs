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
using System.IO;

namespace ActivityOne
{
    public partial class UserForm : Form
    {
        public static string mysqlcon = "server=localhost;user=root;database=userhub;password=";
        public MySqlConnection connection = new MySqlConnection(mysqlcon);
        private byte[] imageData;
        private string selectedImagePath;
        public UserForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void SignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        public void LoadData(string DID, string DName, string DUsername, string DEmail)
        {
            idBox.Text = DID;
            nameBox.Text = DName;
            usernameBox.Text = DUsername;
            emailBox.Text = DEmail;

            byte[] imageData = GetImageDataByUsername(DUsername);

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }

        private byte[] GetImageDataByUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(mysqlcon))
            {
                connection.Open();
                string selectQuery = "SELECT PhotoData FROM userlist WHERE Username = @Username";
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (byte[])result;
                    }
                }
            }
            return null;
        }

        private void UPLOAD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    imageData = File.ReadAllBytes(selectedImagePath);

                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string imageName = Path.GetFileName(selectedImagePath);

            using (MySqlConnection connection = new MySqlConnection(mysqlcon))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE `userlist` SET PhotoData = @photoData, PhotoName = @photoName " +
                                        "WHERE Username = @Username";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        string user = usernameBox.Text;
                        cmd.Parameters.AddWithValue("@photoData", imageData);
                        cmd.Parameters.AddWithValue("@photoName", imageName);
                        cmd.Parameters.AddWithValue("@Username", user);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Image updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Image update failed. No matching user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }


            }
        }

    }
}