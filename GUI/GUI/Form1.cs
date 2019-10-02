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
            LoadImage(current.ImgId);
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
            LoadImage(current.ImgId);
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
            LoadImage(current.ImgId);
            LoadSubjects(0);
        }
        private void LoadImage(int id)
        {
            string img = @"../../images/" + id + ".jpg";
            int BOXHEIGHT = Photo.Height;
            int BOXWIDTH = Photo.Width;
            Image avatar = Image.FromFile(img);
            try
            {
                Photo.Image = avatar;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Image file doesn't exist");
            }
        }

        private void DescriptionButton_Click(object sender, EventArgs e)
        {
        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(LikesLabel.Text, out int likes))
            {
                likes++;
                LikesLabel.Text = likes.ToString();
            }
            else
            {
                Console.WriteLine("Failed to convert likes to integer");
            }
        }

        private void DislikeButton_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(DislikesLabel.Text, out int dislikes))
            {
                dislikes++;
                DislikesLabel.Text = dislikes.ToString();
            }
            else
            {
                Console.WriteLine("Failed to convert dislikes to integer");
            }
        }
    }
}
