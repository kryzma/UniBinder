using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public partial class RegisterForm : Form
    {
        EntryWindowForm mainMenu;
        string username;
        string email;
        string password;
        public RegisterForm(EntryWindowForm mainMenu)
        {
            this.mainMenu = mainMenu;
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            email = textBox2.Text;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            password = textBox3.Text;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (ValidateData(username, email, password))
            {
                UserDataInserter userDataInserter = new UserDataInserter();
                userDataInserter.SendUserData(new Person(DatabaseUserInfo.UserCount(), username, email, password));
                Hide();
                MainProgramForm mainProgram = new MainProgramForm(DatabaseUserInfo.GetUserIDFromName(username), username);
                mainProgram.Show();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            mainMenu.Show();
        }
        private Boolean ValidateData(string name,string email,string password)
        {
            if(name == null || email == null || password == null)
            {
                MessageBox.Show(Properties.Resources.NotAllRegisterFieldsFilled);
                return false;
            }
            if (UsernameInUse(name))
            {
                MessageBox.Show(Properties.Resources.NickNameInUse);
                return false;
            }
            if(!CorrectEmailForm(email))
            {
                MessageBox.Show(email + " write correct email adress","Wrong email adress");
                return false;
            }

            if (EmailInUse(email))
            {
                MessageBox.Show(Properties.Resources.EmailInUse);
                return false;
            }
            
            return true;
        }

        private Boolean CorrectEmailForm(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            //Regex regex = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$");

            Match match = regex.Match(email);
            if (match.Success) return true;
            else return false;
        }
        Boolean UsernameInUse(string name)
        {
            List<Person> userList = AccesUserData.instance.GetUserList();

            return userList.Exists((user) => user.Name.Equals(name));
        }
        Boolean EmailInUse(string email)
        {
            List<Person> userList = AccesUserData.instance.GetUserList();
            return userList.Exists((user) => user.Email.Equals(email));
        }

    }
}
