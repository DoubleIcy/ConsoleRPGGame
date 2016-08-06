using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Configuration;

namespace JProxy
{
    public class DllDoProxy:Interface_Proxy
    {
        #region IDoProxy 成员
        private static readonly string AssemblyString = ConfigurationManager.AppSettings["AssemblyName"].ToString();
        public object DoProxy(string ClassName, string MethodName, object[] args)
        {

            string path = AssemblyString;//项目的Assembly选项名称
            string name = AssemblyString+"." + ClassName; //类的名字
            object Obal = Assembly.Load(path).CreateInstance(name);

            MethodInfo Method = Obal.GetType().GetMethod(MethodName);

            return Method.Invoke(Obal, args);
        }

        public DataTable DoProxyDataTable(string ClassName, string MethodName, object[] args)
        {
            return (DoProxy(ClassName, MethodName, args)as DataSet).Tables[0];
        }

        public DataSet DoProxyDataSet(string ClassName, string MethodName, object[] args)
        {
            return (DataSet)DoProxy(ClassName, MethodName, args);
        }

        public void DoProxyNoResult(string ClassName, string MethodName, object[] args)
        {
            string path = AssemblyString;//项目的Assembly选项名称
            string name = AssemblyString + "." + ClassName; //类的名字
            object Obal = Assembly.Load(path).CreateInstance(name);

            MethodInfo Method = Obal.GetType().GetMethod(MethodName);
            Method.Invoke(Obal, args);
        }
        #endregion
    }
}
