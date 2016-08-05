using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImgForm
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

            string str = string.Format("{0:d}", System.DateTime.Now);
            str += str;
            Application.Run(new Form2());
        }
    }
}
