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
    public partial class EntryWindowForm : Form
    {
        LoginForm loginForm;
        RegisterForm registerForm;

        public EntryWindowForm()
        {
            InitializeComponent();
        }

        private void Register_Button(object sender, EventArgs e)
        {
            if (registerForm == null) registerForm = new RegisterForm(this);

            this.Hide();
            registerForm.Show();
        }

        private void Login_Button(object sender, EventArgs e)
        {
            if (loginForm == null) loginForm = new LoginForm(this);

            this.Hide();
            loginForm.Show();
        }
    }
}
