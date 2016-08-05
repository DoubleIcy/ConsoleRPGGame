using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace ConsoleRPGGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            PropertyInfo[] pi, props;
            PropertyInfo pi1, pi2;
            Type type = typeof(Property);
            object obj = Activator.CreateInstance(type);
            pi=type.GetProperties();
            pi1 = type.GetProperty("live");
            pi2 = type.GetProperty("attack");
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance|BindingFlags.SetProperty);
        }
    }
}
