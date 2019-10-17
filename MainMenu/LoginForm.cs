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
        private MainMenuForm mainMenu;

        public LoginForm(MainMenuForm mainMenu)
        {
            this.mainMenu = mainMenu; 
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if(!CheckFieldValidity(nickname,password))
            {
                MessageBox.Show(Properties.Resources.MissingLoginData);
                return;
            }

            CheckLogIn checkLogin = new CheckLogIn();
            if (checkLogin.CheckLogInValidity(nickname, password))
            {
                Hide();
                MainProgramForm mainProgram = new MainProgramForm(BasicFunctions.GetUserIDFromName(nickname));
                mainProgram.Show();
            }
            else
            {
                MessageBox.Show(Properties.Resources.BadLogin);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            nickname = textBox1.Text;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu.Show();
        }
        private Boolean CheckFieldValidity(string nickname,string password)
        {
            if (nickname == null || password == null) return false;
            return true;
        }
    }
}
