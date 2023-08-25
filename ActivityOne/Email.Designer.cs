namespace ActivityOne
{
    partial class Email
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
            this.Back = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(654, 398);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(134, 40);
            this.Back.TabIndex = 0;
            this.Back.Text = "Close";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(76, 131);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(209, 22);
            this.Display.TabIndex = 2;
            this.Display.TextChanged += new System.EventHandler(this.Display_TextChanged);
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.Back);
            this.Name = "Email";
            this.Text = "Email Notification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox Display;
    }
}