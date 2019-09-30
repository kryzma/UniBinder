using System;

namespace GUI
{
    partial class UniBinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UniBinder));
            this.NameLabel = new System.Windows.Forms.Label();
            this.Photo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Subject1 = new System.Windows.Forms.Label();
            this.Subject2 = new System.Windows.Forms.Label();
            this.Subject3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.PeopleHelpedLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LikesLabel = new System.Windows.Forms.Label();
            this.DislikesLabel = new System.Windows.Forms.Label();
            this.roundButton3 = new GUI.RoundButton();
            this.ForwardButton = new GUI.RoundButton();
            this.BackwardsButton = new GUI.RoundButton();
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(128, 35);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(92, 31);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "NAME";
            this.NameLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Photo
            // 
            this.Photo.Image = ((System.Drawing.Image)(resources.GetObject("Photo.Image")));
            this.Photo.InitialImage = null;
            this.Photo.Location = new System.Drawing.Point(134, 86);
            this.Photo.Name = "Photo";
            this.Photo.Size = new System.Drawing.Size(276, 263);
            this.Photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Photo.TabIndex = 1;
            this.Photo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Help Score";
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.HelpLabel.Location = new System.Drawing.Point(39, 149);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(45, 22);
            this.HelpLabel.TabIndex = 7;
            this.HelpLabel.Text = "9.99";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(444, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Subjects";
            // 
            // Subject1
            // 
            this.Subject1.AutoSize = true;
            this.Subject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Subject1.Location = new System.Drawing.Point(445, 149);
            this.Subject1.Name = "Subject1";
            this.Subject1.Size = new System.Drawing.Size(87, 17);
            this.Subject1.TabIndex = 9;
            this.Subject1.Text = "Mathematics";
            this.Subject1.Click += new System.EventHandler(this.label4_Click);
            // 
            // Subject2
            // 
            this.Subject2.AutoSize = true;
            this.Subject2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Subject2.Location = new System.Drawing.Point(476, 178);
            this.Subject2.Name = "Subject2";
            this.Subject2.Size = new System.Drawing.Size(25, 17);
            this.Subject2.TabIndex = 10;
            this.Subject2.Text = "C#";
            // 
            // Subject3
            // 
            this.Subject3.AutoSize = true;
            this.Subject3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Subject3.Location = new System.Drawing.Point(467, 207);
            this.Subject3.Name = "Subject3";
            this.Subject3.Size = new System.Drawing.Size(38, 17);
            this.Subject3.TabIndex = 11;
            this.Subject3.Text = "Java";
            this.Subject3.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(432, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "Description";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(432, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "Contact";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(4, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 22);
            this.label7.TabIndex = 15;
            this.label7.Text = "People helped";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // PeopleHelpedLabel
            // 
            this.PeopleHelpedLabel.AutoSize = true;
            this.PeopleHelpedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.PeopleHelpedLabel.Location = new System.Drawing.Point(51, 227);
            this.PeopleHelpedLabel.Name = "PeopleHelpedLabel";
            this.PeopleHelpedLabel.Size = new System.Drawing.Size(30, 22);
            this.PeopleHelpedLabel.TabIndex = 16;
            this.PeopleHelpedLabel.Text = "11";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(134, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(355, 366);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label9.Location = new System.Drawing.Point(4, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "Likes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label10.Location = new System.Drawing.Point(57, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 22);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dislikes";
            // 
            // LikesLabel
            // 
            this.LikesLabel.AutoSize = true;
            this.LikesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LikesLabel.Location = new System.Drawing.Point(13, 303);
            this.LikesLabel.Name = "LikesLabel";
            this.LikesLabel.Size = new System.Drawing.Size(30, 22);
            this.LikesLabel.TabIndex = 21;
            this.LikesLabel.Text = "15";
            // 
            // DislikesLabel
            // 
            this.DislikesLabel.AutoSize = true;
            this.DislikesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.DislikesLabel.Location = new System.Drawing.Point(77, 303);
            this.DislikesLabel.Name = "DislikesLabel";
            this.DislikesLabel.Size = new System.Drawing.Size(20, 22);
            this.DislikesLabel.TabIndex = 22;
            this.DislikesLabel.Text = "3";
            // 
            // roundButton3
            // 
            this.roundButton3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.roundButton3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.roundButton3.FlatAppearance.BorderSize = 0;
            this.roundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.roundButton3.ForeColor = System.Drawing.Color.Red;
            this.roundButton3.Location = new System.Drawing.Point(247, 366);
            this.roundButton3.Name = "roundButton3";
            this.roundButton3.Size = new System.Drawing.Size(48, 49);
            this.roundButton3.TabIndex = 12;
            this.roundButton3.Text = "♥";
            this.roundButton3.UseVisualStyleBackColor = false;
            // 
            // ForwardButton
            // 
            this.ForwardButton.BackColor = System.Drawing.Color.SkyBlue;
            this.ForwardButton.FlatAppearance.BorderSize = 0;
            this.ForwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ForwardButton.Location = new System.Drawing.Point(465, 32);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(48, 49);
            this.ForwardButton.TabIndex = 5;
            this.ForwardButton.Text = "→";
            this.ForwardButton.UseVisualStyleBackColor = false;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackwardsButton
            // 
            this.BackwardsButton.BackColor = System.Drawing.Color.SkyBlue;
            this.BackwardsButton.FlatAppearance.BorderSize = 0;
            this.BackwardsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackwardsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BackwardsButton.Location = new System.Drawing.Point(27, 32);
            this.BackwardsButton.Name = "BackwardsButton";
            this.BackwardsButton.Size = new System.Drawing.Size(48, 49);
            this.BackwardsButton.TabIndex = 4;
            this.BackwardsButton.Text = "←";
            this.BackwardsButton.UseVisualStyleBackColor = false;
            this.BackwardsButton.Click += new System.EventHandler(this.BackwardsButton_Click);
            // 
            // UniBinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(544, 427);
            this.Controls.Add(this.DislikesLabel);
            this.Controls.Add(this.LikesLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PeopleHelpedLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roundButton3);
            this.Controls.Add(this.Subject3);
            this.Controls.Add(this.Subject2);
            this.Controls.Add(this.Subject1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HelpLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ForwardButton);
            this.Controls.Add(this.BackwardsButton);
            this.Controls.Add(this.Photo);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UniBinder";
            this.Text = "UniBinder";
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.PictureBox Photo;
        private RoundButton BackwardsButton;
        private RoundButton ForwardButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HelpLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Subject1;
        private System.Windows.Forms.Label Subject2;
        private System.Windows.Forms.Label Subject3;
        private RoundButton roundButton3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label PeopleHelpedLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LikesLabel;
        private System.Windows.Forms.Label DislikesLabel;

    }
}

