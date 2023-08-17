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
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.Showpass = new System.Windows.Forms.CheckBox();
            this.SigninButton = new System.Windows.Forms.Button();
            this.Forgotbtn = new System.Windows.Forms.Button();
            this.Createbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(12, 265);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(280, 22);
            this.Username.TabIndex = 0;
            this.Username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(12, 309);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(280, 22);
            this.Password.TabIndex = 1;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(12, 246);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(84, 16);
            this.UserLabel.TabIndex = 2;
            this.UserLabel.Text = "USERNAME";
            this.UserLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(12, 290);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(86, 16);
            this.PassLabel.TabIndex = 3;
            this.PassLabel.Text = "PASSWORD";
            // 
            // Showpass
            // 
            this.Showpass.AutoSize = true;
            this.Showpass.Location = new System.Drawing.Point(139, 337);
            this.Showpass.Name = "Showpass";
            this.Showpass.Size = new System.Drawing.Size(153, 20);
            this.Showpass.TabIndex = 4;
            this.Showpass.Text = "SHOW PASSWORD";
            this.Showpass.UseVisualStyleBackColor = true;
            this.Showpass.CheckedChanged += new System.EventHandler(this.Showpass_CheckedChanged);
            // 
            // SigninButton
            // 
            this.SigninButton.Location = new System.Drawing.Point(12, 363);
            this.SigninButton.Name = "SigninButton";
            this.SigninButton.Size = new System.Drawing.Size(280, 42);
            this.SigninButton.TabIndex = 5;
            this.SigninButton.Text = "Sign In";
            this.SigninButton.UseVisualStyleBackColor = true;
            this.SigninButton.Click += new System.EventHandler(this.SigninButton_Click);
            // 
            // Forgotbtn
            // 
            this.Forgotbtn.Location = new System.Drawing.Point(155, 411);
            this.Forgotbtn.Name = "Forgotbtn";
            this.Forgotbtn.Size = new System.Drawing.Size(137, 27);
            this.Forgotbtn.TabIndex = 6;
            this.Forgotbtn.Text = "Forgot Password";
            this.Forgotbtn.UseVisualStyleBackColor = true;
            // 
            // Createbtn
            // 
            this.Createbtn.Location = new System.Drawing.Point(12, 411);
            this.Createbtn.Name = "Createbtn";
            this.Createbtn.Size = new System.Drawing.Size(137, 27);
            this.Createbtn.TabIndex = 7;
            this.Createbtn.Text = "Create Account";
            this.Createbtn.UseVisualStyleBackColor = true;
            this.Createbtn.Click += new System.EventHandler(this.Createbtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 450);
            this.Controls.Add(this.Createbtn);
            this.Controls.Add(this.Forgotbtn);
            this.Controls.Add(this.SigninButton);
            this.Controls.Add(this.Showpass);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

