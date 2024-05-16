using System;
using System.Windows.Forms;

namespace JobSpot
{
    internal static class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
            //Application.Run(new Login());
        }
    }
}
