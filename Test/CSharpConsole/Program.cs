using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            b b1 = new b();
            show( b1.test2);
            show(b1.test);
        }
        static void show(string str)
        {

            Console.WriteLine(str);
        }
    }
    public class a
    {
       public string test { get; set; }
       public string test2 { get { return "hehe"; } set { _test2_a = value; } }
       private string _test2_a = "";
    }
    public class b :a
    {
        public string test { get; set; }
        public string test2 { get { return "heng"; }  }
    }

}
