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
    public partial class MainMenu : Form
    {
        LoginForm loginForm;
        RegisterForm registerForm;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (registerForm == null) registerForm = new RegisterForm(this);

            this.Hide();
            registerForm.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(loginForm == null)loginForm = new LoginForm(this);

            this.Hide();
            loginForm.Show();
        }


    }
}
