#define point2
#define point
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Bas
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


#if (pointNo)
            Application.Run(new FormT());
#elif (point3)
            Application.Run(new View());
#else
            Application.Run(new View_1()); 
#endif
        }
    }
}
