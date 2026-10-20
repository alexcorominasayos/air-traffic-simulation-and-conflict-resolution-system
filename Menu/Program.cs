using System;
using System.Windows.Forms;

namespace Menu
{
    internal static class Program
    {
        /// <summary>
        /// Application entry point. The login screen is the main form: closing it ends the program.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
