using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Start GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //UniBinder GUI = new UniBinder();  trying scene 2
            //LoadValues(GUI);
            //GUI.InitialLoad();
            //Application.Run(GUI);

            UserProperties GUI = new UserProperties(); //trying scene 2
            LoadValues(GUI);
           // GUI.InitialLoad();
            Application.Run(GUI);


        }
        static void LoadValues(object gui)
        {
            ////data = dr.UploadData();
            ////int dataLenght = data.Count;
            ////Person current = new Person();
            ////current = data[0];
            ////NameLabel.Text = current.Name;
            ////LoadSubjects();

            //int index = 1;
            //DataReader dr = new DataReader();
            //List<Person> data;

            //data = dr.UploadData();
            //int dataLenght = data.Count;
            //Person current = new Person();
            //current = data[0];
            //NameLabel.Text = current.Name;

        }
    }
}
