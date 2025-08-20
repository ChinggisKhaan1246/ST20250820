using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ST
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Windows Forms-ийн интерфэйсийг тохируулах
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Form-ыг эхлүүлэх
            Application.Run(new FUTUREINNOVATION());
            //Application.Run(new addnotification());
        }
    }
}
