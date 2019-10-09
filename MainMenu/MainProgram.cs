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
    public partial class MainProgram : Form
    {

        private int NORMALISE = 1000;
        private int currentID { get; set; }

        private int totalUsersCount { get; set; }

        UserSettingsMenu userSettingsMenu;

        public MainProgram(int ID)
        {
            this.userSettingsMenu = new UserSettingsMenu(this,ID);
            currentID = 0;
            totalUsersCount = BasicFunctions.UserCount();
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            userSettingsMenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentID--;
            UpdatePerson();
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            UpdatePerson();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentID++;
            UpdatePerson();
        }

        private void UpdatePerson()
        {
            AccesUserData accesUserData = new AccesUserData();
            List<Person> users = accesUserData.GetUserList();
            pictureBox1.Image = users[ (currentID+NORMALISE) % totalUsersCount].image;
            label1.Text = users[(currentID + NORMALISE) % totalUsersCount].Name;
            label3.Text = "";
            foreach(Subject subject in users[(currentID + NORMALISE) % totalUsersCount].Subjects)
            {
                label3.Text += subject.Name;
                label3.Text += "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AccesUserData accesUserData = new AccesUserData();
            List<Person> users = accesUserData.GetUserList();
            System.Windows.Forms.MessageBox.Show("This user's email : " + users[(currentID + NORMALISE) % totalUsersCount].Email );
        }
    }
}
