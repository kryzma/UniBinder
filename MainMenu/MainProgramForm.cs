using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class MainProgramForm : Form
    {

        private int NORMALISE = 1000;
        private int CurrentID { get; set; }

        private int TotalUsersCount { get; set; }

        UserSettingsMenu userSettingsMenu;

        public MainProgramForm(int ID)
        {
            userSettingsMenu = new UserSettingsMenu(this,ID);
            CurrentID = 0;
            TotalUsersCount = BasicFunctions.UserCount();
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Hide();
            userSettingsMenu.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CurrentID--;
            UpdatePerson();
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            UpdatePerson();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CurrentID++;
            UpdatePerson();
        }

        private void UpdatePerson()
        {

            List<Person> users = AccesUserData.instance.GetUserList();
            pictureBox1.Image = users[GetNormalisedCurrentUserId()].image;
            label1.Text = users[GetNormalisedCurrentUserId()].Name;
            label3.Text = "";

            users[GetNormalisedCurrentUserId()].Subjects.ForEach((subject) => label3.Text += subject.Name + '\n');
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<Person> users = AccesUserData.instance.GetUserList();
            MessageBox.Show("This user's email : " + users[GetNormalisedCurrentUserId()].Email );
        }
        private int GetNormalisedCurrentUserId()
        {
            return (CurrentID + NORMALISE) % TotalUsersCount;
        }
    }
}
