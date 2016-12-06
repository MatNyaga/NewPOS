using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string curFile = Environment.CurrentDirectory+"\\FirstRun.ini";
            //First Time Run
            if (File.Exists(curFile))
            {

                Application.Run(new LoginForm());
                
            }
            else {
                // Create the file.
                using (FileStream fs = File.Create(curFile))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("First Time Running the App.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                Application.Run(new welcomepage());
            }
        }
    }
}
