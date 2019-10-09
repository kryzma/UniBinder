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
    public partial class LoginForm : Form
    {
        string nickname;
        string password;

        MainMenu mainMenu;

        public LoginForm(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu; 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(!CheckFieldValidity(nickname,password))
            {
                System.Windows.Forms.MessageBox.Show("Insert login data");
                return;
            }

            CheckLogIn checkLogin = new CheckLogIn();
            if (checkLogin.CheckLogInValidity(nickname, password))
            {
                System.Windows.Forms.MessageBox.Show("Login succesful");
                this.Hide();
                MainProgram mainProgram = new MainProgram(BasicFunctions.UserID(nickname));
                mainProgram.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Login unsuccesful");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nickname = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu.Show();
        }
        private Boolean CheckFieldValidity(string name,string password)
        {
            if (name == null || password == null) return false;
            return true;
        }
    }
}
