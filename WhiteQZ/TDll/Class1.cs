using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace TDll
{
    public class Class1
    {
        Random rd = new Random();
        public void VOID()
        { }
        public string STR1(object OBJ)
        {
            return Convert.ToString(OBJ);
        }
        public string STR()
        {
            return rd.Next(1048, 10000).ToString();
        }
        public string STR(object obj)
        {
            return "string:" + Convert.ToString(obj);
        }
        public DataSet DATASET()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = "从何而来";
            ds.Tables.Add("iniTable");
            return ds;
        }
     
    }
}
