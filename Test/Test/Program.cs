using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Test
{
    class Program
    {
        static void He(){Console.Write("a");}
        void Ho() { Console.Write("a"); }
        static void Main(string[] args)
        {



        }
        #region 
        static void test2()
        {
            DateTime dt1 = DateTime.Now;
            string[] strs=new string[1000];
            string a = "s";
            string b = "t";
            StringBuilder ab = new StringBuilder("s");
            for (int i = 0; i < 100000; i++)
            {
                a += b;
            }
            DateTime dt2 = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                ab.Append(b);
            }
            DateTime dt3 = DateTime.Now; 
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(string.Format("1,{0}  \n\r\t,2,{1}  \n\r\t,3,", dt2 - dt1, dt3 - dt2));
            Console.ReadLine();
        }


        static void test1()
        {
             Program a = new Program();
            DateTime dt1 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                He();
            }
            DateTime dt2 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                a.Ho();
            }
            DateTime dt3 = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("a");
            }
            DateTime dt4 = DateTime.Now;
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(string.Format("1,{0}  \n\r\t,2,{1}  \n\r\t,3,{2}", dt2 - dt1, dt3 - dt2, dt4 - dt3));
            Console.ReadLine();
        #endregion
        }
    }

 
}
