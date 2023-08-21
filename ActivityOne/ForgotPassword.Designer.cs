namespace ActivityOne
{
    partial class ForgotPassword
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
            this.Text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Forgot = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(176)))), ((int)(((byte)(95)))));
            this.Text.Location = new System.Drawing.Point(179, 59);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(246, 37);
            this.Text.TabIndex = 0;
            this.Text.Text = "Find your account";
            this.Text.Click += new System.EventHandler(this.Text_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registered Email:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            // 
            // Username
            // 
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Username.Location = new System.Drawing.Point(20, 12);
            this.Username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(445, 27);
            this.Username.TabIndex = 3;
            // 
            // Email
            // 
            this.Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Email.Location = new System.Drawing.Point(20, 10);
            this.Email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(445, 27);
            this.Email.TabIndex = 4;
            // 
            // Forgot
            // 
            this.Forgot.BackgroundImage = global::ActivityOne.Properties.Resources.rect3;
            this.Forgot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Forgot.FlatAppearance.BorderSize = 0;
            this.Forgot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Forgot.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forgot.Location = new System.Drawing.Point(65, 411);
            this.Forgot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Forgot.Name = "Forgot";
            this.Forgot.Size = new System.Drawing.Size(187, 58);
            this.Forgot.TabIndex = 5;
            this.Forgot.Text = "Remind Me";
            this.Forgot.UseVisualStyleBackColor = true;
            this.Forgot.Click += new System.EventHandler(this.Forgot_Click);
            // 
            // Back
            // 
            this.Back.BackgroundImage = global::ActivityOne.Properties.Resources.rect6;
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Location = new System.Drawing.Point(369, 411);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(188, 58);
            this.Back.TabIndex = 6;
            this.Back.Text = "BACK";
            this.Back.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 50);
            this.label3.TabIndex = 7;
            this.label3.Text = "Please enter your username and email to confirm your account";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ActivityOne.Properties.Resources.rect1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Username);
            this.panel1.Location = new System.Drawing.Point(65, 202);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 49);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ActivityOne.Properties.Resources.rect1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.Email);
            this.panel2.Location = new System.Drawing.Point(65, 310);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 49);
            this.panel2.TabIndex = 13;
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 538);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Forgot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ForgotPassword";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Button Forgot;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}