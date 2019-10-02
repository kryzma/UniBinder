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
        public IList<Subject> subjects;

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


        private void Button2_Click(object sender, EventArgs e)
        {



        }

        private void AddPerson(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Name = NameTextBox.Text;
            person.Age = int.Parse(AgeTextBox.Text);

            DataSerializer d = new DataSerializer();
            d.Serialize(person);

            System.Diagnostics.Debug.WriteLine(SubjectList.SelectedItems[0].ToString());
            System.Diagnostics.Debug.WriteLine(person.Name);
            System.Diagnostics.Debug.WriteLine(person.Age);
            
        }
    }
}
