using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace Capture
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
            //Application.Run(new frmMain());

            // 28/03/2015 - allow only a single instance of application
            string[] args = Environment.GetCommandLineArgs();
            SingleInstanceController controller = new SingleInstanceController();
            controller.Run(args);
            
        }
    }

    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            IsSingleInstance = true;
            StartupNextInstance += this_StartupNextInstance;
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            frmMain form = MainForm as frmMain;
            form.maximizeForm();
        }

        protected override void OnCreateMainForm()
        {
            MainForm = new frmMain();
        }
    }
}
