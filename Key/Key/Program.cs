using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Key
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            while(true)
            {
                while (true)
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        Console.WriteLine("KEK");
                    }
                }
            }
        }

    }
}
