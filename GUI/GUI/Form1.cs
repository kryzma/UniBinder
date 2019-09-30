using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UniBinder : Form
    {
        private int index = 0;
        private DataReader dr = new DataReader();
        private List<Person> data;

        public UniBinder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void ForwardButton_Click(object sender, EventArgs e)
        {
            data = dr.UploadData();
            int dataLenght = data.Count;
            if (dataLenght == index + 1) index = 0;
            else index++;
            Person current = new Person();
            current = data[index];
            LikesLabel.Text = current.Likes.ToString();
            DislikesLabel.Text = current.Dislikes.ToString();
            HelpLabel.Text = current.HelpScore.ToString();
            NameLabel.Text = current.Name;
            PeopleHelpedLabel.Text = current.PeopleHelped.ToString();
            LoadSubjects(index);
        }

        private void BackwardsButton_Click(object sender, EventArgs e)
        {
            data = dr.UploadData();
            int dataLenght = data.Count;
            if (index == 0) index = dataLenght - 1;
            else index--;
            Person current = new Person();
            current = data[index];
            LikesLabel.Text = current.Likes.ToString();
            DislikesLabel.Text = current.Dislikes.ToString();
            HelpLabel.Text = current.HelpScore.ToString();
            NameLabel.Text = current.Name;
            PeopleHelpedLabel.Text = current.PeopleHelped.ToString();
            LoadSubjects(index);
        }
        private void LoadSubjects(int indx)
        {
            if (data[indx].Subjects.Count >= 1)
                Subject1.Text = data[index].Subjects[0].SubjectName;
            else Subject1.Text = "";

            if (data[indx].Subjects.Count >= 2)
                Subject2.Text = data[index].Subjects[1].SubjectName;
            else Subject2.Text = "";

            if (data[indx].Subjects.Count >= 3)
                Subject3.Text = data[index].Subjects[2].SubjectName;
            else Subject3.Text = "";
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void InitialLoad()
        {
            data = dr.UploadData();
            int dataLenght = data.Count;
            Person current = new Person();
            current = data[0];
            LikesLabel.Text = current.Likes.ToString();
            DislikesLabel.Text = current.Dislikes.ToString();
            HelpLabel.Text = current.HelpScore.ToString();
            NameLabel.Text = current.Name;
            PeopleHelpedLabel.Text = current.PeopleHelped.ToString();
            LoadSubjects(0);
        }
    }
}
