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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.UserInfo = new System.Windows.Forms.DataGridView();
            this.Backbtn = new System.Windows.Forms.Button();
            this.Activate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // UserInfo
            // 
            this.UserInfo.AllowUserToAddRows = false;
            this.UserInfo.AllowUserToDeleteRows = false;
            this.UserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.UserInfo.Location = new System.Drawing.Point(13, 13);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.ReadOnly = true;
            this.UserInfo.RowHeadersWidth = 51;
            this.UserInfo.RowTemplate.Height = 24;
            this.UserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserInfo.Size = new System.Drawing.Size(775, 387);
            this.UserInfo.TabIndex = 0;
            // 
            // Backbtn
            // 
            this.Backbtn.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.Backbtn.Location = new System.Drawing.Point(651, 406);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(137, 32);
            this.Backbtn.TabIndex = 2;
            this.Backbtn.Text = "Back";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // Activate
            // 
            this.Activate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.Activate.Location = new System.Drawing.Point(13, 407);
            this.Activate.Name = "Activate";
            this.Activate.Size = new System.Drawing.Size(137, 31);
            this.Activate.TabIndex = 3;
            this.Activate.Text = "Activate";
            this.Activate.UseVisualStyleBackColor = true;
            this.Activate.Click += new System.EventHandler(this.Activate_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Activate);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.UserInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.Text = "UserHub Admin";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UserInfo;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button Activate;
    }
}