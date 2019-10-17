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
        MainProgramForm mainProgram;

        private int ID { get; set; }

        public UserSettingsMenu(MainProgramForm mainProgram,int ID)
        {
            this.ID = ID;
            this.mainProgram = mainProgram;
            InitializeComponent();
            SetUpCheckedList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
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
            subjects.ForEach((subject) => checkedListBox1.Items.Add(subject.Name));
        }

        private void GetSubjectsList()
        {
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader(Properties.Resources.GetExistingSubjects);

            while (reader.Read())
            {
                subjects.Add(new Subject(reader.GetString(0)));
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClearOldSubjects();
            LoadNewSubjects();
            Hide();
            mainProgram.Show();
        }
        private void ClearOldSubjects()
        {
            DataBaseHelper.instance.SqlCommandExcecutor("Delete from Subjects Where ID = " + ID);
        }
        private void LoadNewSubjects()
        {
            // ITERATE OVER checkedlist and insert subjects

            //checkedListBox1.CheckedItems.GetEnumerator

        }
        private void LoadImage()
        {
            ImageProcessor imageProcessor = new ImageProcessor();
            string query = "UPDATE Persons SET Image = '" + 
                imageProcessor.ImageToBase64(image, System.Drawing.Imaging.ImageFormat.Png) + "' where ID =" + ID;
            DataBaseHelper.instance.SqlCommandExcecutor(query);
        }
    }
}
