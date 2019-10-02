using System.Drawing;

namespace GUI
{
    partial class UserProperties
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
            this.AddPersonButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AgeTextBox = new System.Windows.Forms.TextBox();
            this.SubjectList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // AddPersonButton
            // 
            this.AddPersonButton.Location = new System.Drawing.Point(28, 191);
            this.AddPersonButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddPersonButton.Name = "AddPersonButton";
            this.AddPersonButton.Size = new System.Drawing.Size(93, 28);
            this.AddPersonButton.TabIndex = 1;
            this.AddPersonButton.Tag = "";
            this.AddPersonButton.Text = "Add User";
            this.AddPersonButton.UseVisualStyleBackColor = true;
            this.AddPersonButton.Click += new System.EventHandler(this.AddPerson);
            // 
            // NameTextBox
            // 
            this.NameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.NameTextBox.Location = new System.Drawing.Point(28, 55);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(113, 20);
            this.NameTextBox.TabIndex = 2;
            this.NameTextBox.Tag = "NameTextBox";
            this.NameTextBox.Text = "Name";
            this.NameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // AgeTextBox
            // 
            this.AgeTextBox.ForeColor = System.Drawing.Color.Gray;
            this.AgeTextBox.Location = new System.Drawing.Point(28, 88);
            this.AgeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AgeTextBox.Name = "AgeTextBox";
            this.AgeTextBox.Size = new System.Drawing.Size(113, 20);
            this.AgeTextBox.TabIndex = 3;
            this.AgeTextBox.Tag = "AgeTextBox";
            this.AgeTextBox.Text = "Age";
            this.AgeTextBox.Enter += new System.EventHandler(this.AgeTextBox_Enter);
            this.AgeTextBox.Leave += new System.EventHandler(this.AgeTextBox_Leave);
            // 
            // SubjectList
            // 
            this.SubjectList.FormattingEnabled = true;
            this.SubjectList.Location = new System.Drawing.Point(204, 55);
            this.SubjectList.Margin = new System.Windows.Forms.Padding(2);
            this.SubjectList.Name = "SubjectList";
            this.SubjectList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.SubjectList.Size = new System.Drawing.Size(188, 121);
            this.SubjectList.TabIndex = 7;
            // 
            // UserProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 281);
            this.Controls.Add(this.SubjectList);
            this.Controls.Add(this.AgeTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.AddPersonButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserProperties";
            this.Text = "UserProperties";
            this.Load += new System.EventHandler(this.UserProperties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddPersonButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox AgeTextBox;
        private System.Windows.Forms.ListBox SubjectList;
    }
}