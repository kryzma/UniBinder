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
    public partial class RegisterForm : Form
    {
        MainMenu mainMenu;
        string username;
        string email;
        string password;
        public RegisterForm(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.email = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.password = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validateData(this.username, this.email, this.password)){
                System.Windows.Forms.MessageBox.Show("Account created succesfully");
                UserDataInserter userDataInserter = new UserDataInserter();
                Person person = new Person(BasicFunctions.UserCount(),this.username, this.email, this.password);
                userDataInserter.sendUserData(person);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu.Show();
        }


        Boolean validateData(string name,string email,string password)
        {
            if(name == null || email == null || password == null)
            {
                System.Windows.Forms.MessageBox.Show("Please fill all fields");
                return false;
            }
            if (usernameInUse(name))
            {
                System.Windows.Forms.MessageBox.Show("Try different nickname");
                return false;
            }
            if (emailInUse(email))
            {
                System.Windows.Forms.MessageBox.Show("Try different email");
                return false;
            }
            return true;
        }
        Boolean usernameInUse(string name)
        {
            AccesUserData accesUserData = new AccesUserData();
            List<Person> userList = accesUserData.GetUserList();
            foreach(var user in userList)
            {
                if(user.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        Boolean emailInUse(string email)
        {
            AccesUserData accesUserData = new AccesUserData();
            List<Person> userList = accesUserData.GetUserList();
            foreach (var user in userList)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
