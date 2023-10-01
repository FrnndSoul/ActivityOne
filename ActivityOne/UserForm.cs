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
            System.Drawing.Drawing2D.GraphicsPath obj = new System.Drawing.Drawing2D.GraphicsPath();
            obj.AddEllipse(0, 0,pictureBox1.Width,pictureBox1.Height);
            Region rg = new Region(obj);
            pictureBox1.Region = rg;
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
            DialogResult result = MessageBox.Show("Do you want to use this as your profile photo?","Confirmation",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
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
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");
                    }
                }
            } else
            {
                string DUsername = usernameBox.Text;
                byte[] imageData = GetImageDataByUsername(DUsername);

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    pictureBox1.Image = ActivityOne.Properties.Resources.download;
                    return;
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}