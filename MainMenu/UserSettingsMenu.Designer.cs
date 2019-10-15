namespace LogIn
{
    partial class UserSettingsMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SubjectListBox = new System.Windows.Forms.CheckedListBox();
            this.UserImageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 82);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "UploadImage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UploadImage_Button);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(487, 401);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ConfirmData_Button);
            // 
            // SubjectListBox
            // 
            this.SubjectListBox.FormattingEnabled = true;
            this.SubjectListBox.Location = new System.Drawing.Point(763, 118);
            this.SubjectListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SubjectListBox.Name = "SubjectListBox";
            this.SubjectListBox.Size = new System.Drawing.Size(247, 276);
            this.SubjectListBox.TabIndex = 2;
            // 
            // UserImageBox
            // 
            this.UserImageBox.Location = new System.Drawing.Point(16, 118);
            this.UserImageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserImageBox.Name = "UserImageBox";
            this.UserImageBox.Size = new System.Drawing.Size(435, 340);
            this.UserImageBox.TabIndex = 3;
            this.UserImageBox.TabStop = false;
            // 
            // UserSettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.UserImageBox);
            this.Controls.Add(this.SubjectListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserSettingsMenu";
            this.Text = "UserSettingsMenu";
            ((System.ComponentModel.ISupportInitialize)(this.UserImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox SubjectListBox;
        private System.Windows.Forms.PictureBox UserImageBox;
    }
}