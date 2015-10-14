using System;
using System.Threading;
using System.Windows.Forms;

namespace Pitman.Presentation.Winform
{
    static class Program
    {
        private static Mutex mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            mutex = new Mutex(true, "OnlyRun");
            if (mutex.WaitOne(0, false))
            {
                System.Windows.Forms.Application.Run(new Main());
            }
            else
            {
                MessageBox.Show("程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
