using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRPGGame
{
    class Program
    {
        static void Main(string[] args)
        { 
            Type type = typeof(Property);
            object obj=Activator.CreateInstance(type);
            type.GetProperties();
            type.GetProperty("live"); 
        }
    }
}
