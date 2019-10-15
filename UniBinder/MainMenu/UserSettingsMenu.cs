using System;
using System.Collections;
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
    public partial class UserSettingsMenu : Form, IEnumerator
    {
        private Image image;
        private List<Subject> subjects = new List<Subject>();
        MainProgramForm mainProgram;

        private int ID { get; set; }

        public object Current => throw new NotImplementedException();

        public UserSettingsMenu(MainProgramForm mainProgram,int ID)
        {
            this.ID = ID;
            this.mainProgram = mainProgram;
            InitializeComponent();
            SetUpCheckedList();
        }

        private void SetUpCheckedList()
        {
            GetSubjectsList();
            IEnumerator enumerator = subjects.GetEnumerator();
            while(enumerator.MoveNext())
            {
                var subject = (Subject)enumerator.Current;
                SubjectListBox.Items.Add(subject.Name);
            }

            //subjects.ForEach((subject) => checkedListBox1.Items.Add(subject.Name));
        }

        private void GetSubjectsList()
        {
            SqlDataReader reader = DataBaseHelper.instance.GetSqlDataReader(Properties.Resources.GetExistingSubjects);

            while (reader.Read())
            {
                subjects.Add(new Subject(reader.GetString(0)));
            }
        }

        private void ClearOldSubjects()
        {
            DataBaseHelper.instance.SqlCommandExcecutor("Delete from Subjects Where ID = " + ID);
        }
        private void LoadNewSubjects()
        {
            // ITERATE OVER checkedlist and insert subjects
            //checkedListBox1.CheckedItems.GetEnumerator
            foreach(var item in SubjectListBox.CheckedItems)
            {
                DataBaseHelper.instance.SqlCommandExcecutor("Insert into Subjects values('" + ID + "','" + item + "')");
            }
        }

        private void LoadImage()
        {
            ImageProcessor imageProcessor = new ImageProcessor();
            string query = "UPDATE Persons SET Image = '" + 
                imageProcessor.ImageToBase64(image, System.Drawing.Imaging.ImageFormat.Png) + "' where ID =" + ID;
            DataBaseHelper.instance.SqlCommandExcecutor(query);
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        private void UploadImage_Button(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                image = Image.FromFile(selectedFile);
                UserImageBox.Image = image;
            }
            LoadImage();
        }

        private void ConfirmData_Button(object sender, EventArgs e)
        {
            ClearOldSubjects();
            LoadNewSubjects();
            Hide();
            mainProgram.Show();
        }
    }
}
