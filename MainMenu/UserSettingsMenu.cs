using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class UserSettingsMenu : Form
    {
        private Image image;
        private List<Subject> subjects = new List<Subject>();
        MainProgram mainProgram;

        private int ID { get; set; }

        public UserSettingsMenu(MainProgram mainProgram,int ID)
        {
            ImageProcessor imageProcessor = new ImageProcessor();
            this.image = imageProcessor.defaultImage;
            this.ID = ID;
            this.mainProgram = mainProgram;
            InitializeComponent();
            SetUpCheckedList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                image = Image.FromFile(selectedFile);
                pictureBox1.Image = image;
            }
            LoadImage();
        }

        private void SetUpCheckedList()
        {
            GetSubjectsList();
            foreach(var subject in this.subjects)
            {
                checkedListBox1.Items.Add(subject.Name);
            }
        }

        private void GetSubjectsList()
        {
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            string personInfoQuerry = "select * from subjectslist";
            SqlCommand command = new SqlCommand(personInfoQuerry, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                this.subjects.Add(new Subject(reader.GetString(0)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearOldSubjects();
            LoadNewSubjects();
            this.Hide();
            mainProgram.Show();
        }
        private void ClearOldSubjects()
        {
            string querry = "Delete from Subjects Where ID = " + ID;
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(querry, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        private void LoadNewSubjects()
        {
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            foreach(string subject in checkedListBox1.CheckedItems)
            {
                string querry = "Insert into Subjects values('" + ID + "','" + subject + "')";
                SqlCommand command = new SqlCommand(querry, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        private void LoadImage()
        {
            ImageProcessor imageProcessor = new ImageProcessor();
            string querry = "UPDATE Persons SET Image = '" + 
                imageProcessor.ImageToBase64(image, System.Drawing.Imaging.ImageFormat.Png) + "' where ID =" + ID;
            SqlConnection connection = DataBaseInfo.getSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(querry, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
