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
    public partial class Email : Form
    {
        private string userPassword;
        public Email()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void SetPassword(string password)
        {
            userPassword = password;
            Display.Text = userPassword;
            Display.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Display_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
