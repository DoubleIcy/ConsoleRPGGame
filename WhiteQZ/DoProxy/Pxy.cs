using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace DoProxy
{
    public class Pxy
    { 
        public static void show()
        {
            //测试dll，非引用，而套用会怎样
            object ob1, ob2, ob3, ob4, ob5;
            ob1 = DllLoad("TDll", "Class1", "STR1", new object[] { "T" });
            ob2 = DllLoad("TDll", "Class1", "STR1", new object[] { "s" });
            ob3 = DllLoad("TDll", "Class1", "STR1", new object[] { new TimeSpan() });

            ob4 = DllLoad("TDll", "Class1", "DATASET", new object[] { });

            ob5 = DllLoad("TDll", "Class1", "DATASET", new object[] { });
            string str = string.Format("", ob1, ob2, ob3, ob4, ob5);
        }

        /// <summary>
        /// dll调用，保持方法名唯一，参数正确
        /// </summary>
        /// <param name="AssemblyString"></param>
        /// <param name="ClassName"></param>
        /// <param name="MethodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object DllLoad(string AssemblyString, string ClassName, string MethodName, object[] args)
        {
            string path = AssemblyString;//项目的Assembly选项名称
            string name = AssemblyString + "." + ClassName; //类的名字
            object Obal = Assembly.Load(path).CreateInstance(name);

            MethodInfo Method = Obal.GetType().GetMethod(MethodName);
            return Method.Invoke(Obal, args);
        }
    }
}
