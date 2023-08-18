namespace ActivityOne
{
    partial class AdminForm
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
            this.UserInfo = new System.Windows.Forms.DataGridView();
            this.tblName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblActivation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblPUK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Backbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // UserInfo
            // 
            this.UserInfo.AllowUserToAddRows = false;
            this.UserInfo.AllowUserToDeleteRows = false;
            this.UserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tblName,
            this.tblUsername,
            this.tblEmail,
            this.tblPassword,
            this.tblActivation,
            this.tblPUK});
            this.UserInfo.Location = new System.Drawing.Point(10, 11);
            this.UserInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.ReadOnly = true;
            this.UserInfo.RowHeadersWidth = 51;
            this.UserInfo.RowTemplate.Height = 24;
            this.UserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserInfo.Size = new System.Drawing.Size(581, 290);
            this.UserInfo.TabIndex = 0;
            this.UserInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tblName
            // 
            this.tblName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tblName.HeaderText = "Name";
            this.tblName.MinimumWidth = 6;
            this.tblName.Name = "tblName";
            this.tblName.ReadOnly = true;
            // 
            // tblUsername
            // 
            this.tblUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tblUsername.HeaderText = "Username";
            this.tblUsername.MinimumWidth = 6;
            this.tblUsername.Name = "tblUsername";
            this.tblUsername.ReadOnly = true;
            // 
            // tblEmail
            // 
            this.tblEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tblEmail.HeaderText = "Email";
            this.tblEmail.MinimumWidth = 6;
            this.tblEmail.Name = "tblEmail";
            this.tblEmail.ReadOnly = true;
            // 
            // tblPassword
            // 
            this.tblPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tblPassword.HeaderText = "Password";
            this.tblPassword.MinimumWidth = 6;
            this.tblPassword.Name = "tblPassword";
            this.tblPassword.ReadOnly = true;
            // 
            // tblActivation
            // 
            this.tblActivation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tblActivation.HeaderText = "Activation";
            this.tblActivation.MinimumWidth = 6;
            this.tblActivation.Name = "tblActivation";
            this.tblActivation.ReadOnly = true;
            // 
            // tblPUK
            // 
            this.tblPUK.HeaderText = "PUK";
            this.tblPUK.MinimumWidth = 6;
            this.tblPUK.Name = "tblPUK";
            this.tblPUK.ReadOnly = true;
            this.tblPUK.Width = 125;
            // 
            // Backbtn
            // 
            this.Backbtn.Location = new System.Drawing.Point(488, 330);
            this.Backbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(103, 26);
            this.Backbtn.TabIndex = 2;
            this.Backbtn.Text = "Back";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Activate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.UserInfo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminForm";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UserInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblActivation;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tblPUK;
        private System.Windows.Forms.Button button1;
    }
}