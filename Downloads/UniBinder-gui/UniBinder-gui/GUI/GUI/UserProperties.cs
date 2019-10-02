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
    public partial class UserProperties : Form
    {
        public UserProperties()
        {
            InitializeComponent();
            InitSubjects();
        }

        private void AddSubject(object sender, EventArgs e)
        {

            
            
        }

        private void InitSubjects()
        {
            SubjectList.Items.Add("Physics");
            SubjectList.Items.Add("Maths");
        }


        private void AddPerson(object sender, EventArgs e)
        {
            List<Subject> subjects = new List<Subject>();
            AddSubjectsToList(subjects);
            var person = CreatePersonFromTxtBox(subjects);
            DataSerializer d = new DataSerializer();
            d.Serialize(person);

            Testprint(person);
            UniBinder MainScene = new UniBinder();
            MainScene.ShowDialog();
            //CreatePersonFromTxtBox();
        }

        private void Testprint(Person person)
        {
            //System.Diagnostics.Debug.WriteLine(SubjectList.SelectedItems[0].ToString());
            System.Diagnostics.Debug.WriteLine(person.Name);
            System.Diagnostics.Debug.WriteLine(person.Age);
        }

        private void AddSubjectsToList(List<Subject> subjects)
        {
            if (SubjectList.SelectedItems.Count != 0)
            {
                foreach (var item in SubjectList.SelectedItems)
                {
                    Subject subject = new Subject();
                    subject.Name = item.ToString();
                    subjects.Add(subject);
                }
            }
            else
            {
                validateUserEntry(subjects);
            }
    }

        private void validateUserEntry(List<Subject> subjects)
        {
            // Checks the value of the text.

            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                
            }
            else
            {
                CreatePersonFromTxtBox(subjects);
            }
        }



        private Person CreatePersonFromTxtBox(List<Subject> subjects)
        {
            Person person = new Person();
            person.Name = NameTextBox.Text;
            person.Age = int.Parse(AgeTextBox.Text);
            person.Subjects = subjects;
            return person;
        }

        private void UserProperties_Load(object sender, EventArgs e)
        {

        }
    }
}
