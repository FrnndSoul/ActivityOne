namespace ActivityOne
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.Showpass = new System.Windows.Forms.CheckBox();
            this.Forgotbtn = new System.Windows.Forms.Button();
            this.Createbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Password = new System.Windows.Forms.TextBox();
            this.SigninButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.Location = new System.Drawing.Point(61, 184);
            this.UserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(77, 17);
            this.UserLabel.TabIndex = 2;
            this.UserLabel.Text = "USERNAME";
            this.UserLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassLabel.Location = new System.Drawing.Point(61, 260);
            this.PassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(78, 17);
            this.PassLabel.TabIndex = 3;
            this.PassLabel.Text = "PASSWORD";
            // 
            // Showpass
            // 
            this.Showpass.AutoSize = true;
            this.Showpass.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Showpass.Location = new System.Drawing.Point(64, 323);
            this.Showpass.Margin = new System.Windows.Forms.Padding(2);
            this.Showpass.Name = "Showpass";
            this.Showpass.Size = new System.Drawing.Size(107, 17);
            this.Showpass.TabIndex = 4;
            this.Showpass.Text = "Show Password";
            this.Showpass.UseVisualStyleBackColor = true;
            this.Showpass.CheckedChanged += new System.EventHandler(this.Showpass_CheckedChanged);
            // 
            // Forgotbtn
            // 
            this.Forgotbtn.Location = new System.Drawing.Point(236, 451);
            this.Forgotbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Forgotbtn.Name = "Forgotbtn";
            this.Forgotbtn.Size = new System.Drawing.Size(103, 22);
            this.Forgotbtn.TabIndex = 6;
            this.Forgotbtn.Text = "Forgot Password";
            this.Forgotbtn.UseVisualStyleBackColor = true;
            this.Forgotbtn.Click += new System.EventHandler(this.Forgotbtn_Click);
            // 
            // Createbtn
            // 
            this.Createbtn.Location = new System.Drawing.Point(104, 451);
            this.Createbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Createbtn.Name = "Createbtn";
            this.Createbtn.Size = new System.Drawing.Size(103, 22);
            this.Createbtn.TabIndex = 7;
            this.Createbtn.Text = "Create Account";
            this.Createbtn.UseVisualStyleBackColor = true;
            this.Createbtn.Click += new System.EventHandler(this.Createbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Log in to your account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(176)))), ((int)(((byte)(95)))));
            this.label2.Location = new System.Drawing.Point(141, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 45);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ActivityOne.Properties.Resources.rect1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.Password);
            this.panel2.Location = new System.Drawing.Point(54, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 40);
            this.panel2.TabIndex = 11;
            // 
            // Password
            // 
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Password.Location = new System.Drawing.Point(10, 9);
            this.Password.Margin = new System.Windows.Forms.Padding(2);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(342, 22);
            this.Password.TabIndex = 1;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // SigninButton
            // 
            this.SigninButton.BackColor = System.Drawing.Color.Transparent;
            this.SigninButton.BackgroundImage = global::ActivityOne.Properties.Resources.rect21;
            this.SigninButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SigninButton.Location = new System.Drawing.Point(54, 366);
            this.SigninButton.Margin = new System.Windows.Forms.Padding(2);
            this.SigninButton.Name = "SigninButton";
            this.SigninButton.Size = new System.Drawing.Size(369, 39);
            this.SigninButton.TabIndex = 5;
            this.SigninButton.Text = "Sign In";
            this.SigninButton.UseVisualStyleBackColor = false;
            this.SigninButton.Click += new System.EventHandler(this.SigninButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ActivityOne.Properties.Resources.rect1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Username);
            this.panel1.Location = new System.Drawing.Point(54, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 40);
            this.panel1.TabIndex = 10;
            // 
            // Username
            // 
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Username.Location = new System.Drawing.Point(10, 9);
            this.Username.Margin = new System.Windows.Forms.Padding(2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(335, 22);
            this.Username.TabIndex = 0;
            this.Username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(470, 570);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Createbtn);
            this.Controls.Add(this.Forgotbtn);
            this.Controls.Add(this.SigninButton);
            this.Controls.Add(this.Showpass);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.CheckBox Showpass;
        private System.Windows.Forms.Button SigninButton;
        private System.Windows.Forms.Button Forgotbtn;
        private System.Windows.Forms.Button Createbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

