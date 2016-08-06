using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;


namespace JProxy
{
    public class Proxy
    {
        //处理方式：0，为正常使用 1 WCF 

        private static string DealType = System.Configuration.ConfigurationManager.AppSettings["ConfigDeal"].ToString();
        private static Interface_Proxy DoProxyClient = null;

        private static Interface_Proxy GetDoProxy()
        {
            if (DoProxyClient == null)
            {
                string path = "JProxy";//项目的Assembly选项名称
            
                string name = "JProxy." + (DealType == "0" ? "DllDoProxy" : "WCFDoProxy"); //类的名字
                DoProxyClient = (Interface_Proxy)Assembly.Load(path).CreateInstance(name);
            }
            return DoProxyClient;
        }
        
        public static DataSet DoProxyDataSet(string ClassName, string MethodName, object[] args)
        {
            return GetDoProxy().DoProxyDataSet(ClassName, MethodName, args);
        }

        public static DataTable DoProxyDataTable(string ClassName, string MethodName, object[] args)
        {
            return GetDoProxy().DoProxyDataTable(ClassName, MethodName, args);
        }

        public static object DoProxy(string ClassName, string MethodName, object[] args)
        {
            return GetDoProxy().DoProxy(ClassName, MethodName, args);
        }

        public static void DoProxyNoResult(string ClassName, string MethodName, object[] args)
        {
            GetDoProxy().DoProxyNoResult(ClassName, MethodName, args);
        }
    }
}
