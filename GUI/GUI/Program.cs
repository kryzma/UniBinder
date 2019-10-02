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
            UserProperties GUI = new UserProperties();
            Application.Run(GUI);
     
        }
    }
}
