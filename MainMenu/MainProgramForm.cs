using System;
using System.Collections;
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
    public partial class MainProgramForm : Form, IEnumerable
    {

        private int NORMALISE = 1000;
        private int currentID { get; set; }

        private int totalUsersCount { get; set; }

        private string userName { get; set; }

        UserSettingsMenu userSettingsMenu;

        public MainProgramForm(int ID, string Name)
        {
            userSettingsMenu = new UserSettingsMenu(this,ID);
            currentID = 0;
            userName = Name;
            totalUsersCount = DatabaseUserInfo.UserCount();
            InitializeComponent();
        }


        private void MainProgram_Load(object sender, EventArgs e)
        {
            UpdatePerson();
        }

        private void UpdatePerson()
        {
            List<Person> users = AccesUserData.instance.GetUserList();
            if (users[GetNormalisedCurrentUserId()].Name == userName)


            Console.WriteLine(users.Count);
            pictureBox1.Image = users[GetNormalisedCurrentUserId()].image;
            label1.Text = users[GetNormalisedCurrentUserId()].Name;
            label3.Text = "";
            users[GetNormalisedCurrentUserId()].Subjects.ForEach((subject) => label3.Text += subject.Name + '\n');
        }

        private void UpdatePersonLeft()
        {
            List<Person> users = AccesUserData.instance.GetUserList();
            if (users[GetNormalisedCurrentUserId()].Name == userName) currentID--;
            UpdateNamePhoto(users);
        }

        private void UpdatePersonRight()
        {
            List<Person> users = AccesUserData.instance.GetUserList();
            if (users[GetNormalisedCurrentUserId()].Name == userName) currentID++;
            UpdateNamePhoto(users);
        }

        private void UpdateNamePhoto(List<Person> users)
        {
            pictureBox1.Image = users[GetNormalisedCurrentUserId()].image;
            label1.Text = users[GetNormalisedCurrentUserId()].Name;
            label3.Text = "";
            users[GetNormalisedCurrentUserId()].Subjects.ForEach((subject) => label3.Text += subject.Name + '\n');
        }

        private int GetNormalisedCurrentUserId()
        {
            return (currentID + NORMALISE) % totalUsersCount;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void UserSettings_Button(object sender, EventArgs e)
        {
            Hide();
            
            userSettingsMenu.Show();
        }

        private void SwipeLeft_Button(object sender, EventArgs e)
        {
            currentID--;
            UpdatePersonLeft();
            //UpdatePerson();
        }

        private void SwipeRight_Button(object sender, EventArgs e)
        {
            currentID++;
            UpdatePersonRight();
        }

        private void NextRightPerson()
        {
            //if (CurrentID == userSettingsMenu.GetCurrentUserID()) CurrentID++;
            //if (CurrentID == userSettingsMenu.GetCurrentUserID()) Console.WriteLine(CurrentID);
            //List<Person> users = AccesUserData.instance.GetUserList();
            //if (users[CurrentID].Name == UserName) Console.WriteLine(UserName);
            //UpdatePerson();
        }


        private void Contacts_Button(object sender, EventArgs e)
        {
            List<Person> users = AccesUserData.instance.GetUserList();
            MessageBox.Show("This user's email : " + users[GetNormalisedCurrentUserId()].Email);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
