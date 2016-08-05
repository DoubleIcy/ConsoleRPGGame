using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;


namespace EmeManager
{
    public class RaykingProxyClient
    {
        //处理方式：0，为正常使用 1 WCF 

        private static readonly string DealType = System.Configuration.ConfigurationManager.AppSettings["DealType"].ToString();
        private static IDoProxy DoProxyClient = null;

        private static IDoProxy GetDoProxy()
        {
            if (DoProxyClient == null)
            {
                string path = "EmeManager.Proxy";//项目的Assembly选项名称
            
                string name = "EmeManager." + (DealType == "0" ? "DllDoProxy" : "WCFDoProxy"); //类的名字
                DoProxyClient = (IDoProxy)Assembly.Load(path).CreateInstance(name);
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
