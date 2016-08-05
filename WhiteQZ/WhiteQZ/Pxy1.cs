using System;
using System.Data;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WhiteQZ
{
    public partial class Pxy1 : DevExpress.XtraEditors.XtraForm
    {
        public Pxy1()
        {
            InitializeComponent();
        }

        static void Proxy()
        {
            DoProxy.Pxy.show();

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
        static object DllLoad(string AssemblyString, string ClassName, string MethodName, object[] args)
        {
            string path = AssemblyString;//项目的Assembly选项名称
            string name = AssemblyString + "." + ClassName; //类的名字
            object Obal = Assembly.Load(path).CreateInstance(name);

            MethodInfo Method = Obal.GetType().GetMethod(MethodName);
            return Method.Invoke(Obal, args);
        }
        #region
        string AssemblyName = "";
        //public object WCFDoProxy(string ClassName, string MethodName, object[] args)
        //{
        //    if (args != null)
        //        for (int i = 0; i < args.Length; i++)
        //        {
        //            if (args[i] is DataSet)
        //            {
        //                args[i] = DataSetToBytes(CopyDataSet((DataSet)args[i]));
        //            }
        //        }
        //    ProxyClient ProxyClient = new ProxyClient();
        //    ProxyClient.ClientCredentials.UserName.UserName = "user";
        //    ProxyClient.ClientCredentials.UserName.Password = "pass";
        //    object obj = ProxyClient.DoProxy(AssemblyName, ClassName, MethodName, args);
        //    if (obj is byte[])
        //        obj = BytesToDataset((byte[])obj);
        //    return obj;
        //}

        public static DataSet CopyDataSet(DataSet SrcDS)
        {
            DataTable SrcTB, DstTB = null;
            DataSet RjDs = new DataSet();

            foreach (DataTable dt in SrcDS.Tables)
            {
                SrcTB = dt;
                DstTB = new DataTable(dt.TableName);
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    DstTB.Columns.Add(dt.Columns[col].ColumnName, dt.Columns[col].DataType);
                }
                DataColumn[] PKColumn = dt.PrimaryKey;

                if (PKColumn.Length > 0)
                {
                    DataColumn[] keys = new DataColumn[PKColumn.Length];
                    for (int pkc = 0; pkc < PKColumn.Length; pkc++)
                    {
                        keys[pkc] = DstTB.Columns[PKColumn[pkc].ColumnName];
                    }
                    DstTB.PrimaryKey = keys;
                }

                for (int i = 0; i < SrcTB.Rows.Count; i++)
                {
                    DataRow tmpRow = DstTB.NewRow();

                    switch (SrcTB.Rows[i].RowState)
                    {
                        case DataRowState.Added:
                            for (int j = 0; j < DstTB.Columns.Count; j++)
                            {
                                tmpRow[DstTB.Columns[j].ColumnName] = SrcTB.Rows[i][DstTB.Columns[j].ColumnName];
                            }
                            DstTB.Rows.Add(tmpRow);
                            break;

                        case DataRowState.Modified:
                            for (int j = 0; j < DstTB.Columns.Count; j++)
                            {
                                tmpRow[DstTB.Columns[j].ColumnName] = SrcTB.Rows[i][DstTB.Columns[j].ColumnName, DataRowVersion.Original];
                            }
                            DstTB.Rows.Add(tmpRow);
                            tmpRow.AcceptChanges();

                            for (int j = 0; j < DstTB.Columns.Count; j++)
                            {
                                tmpRow[DstTB.Columns[j].ColumnName] = SrcTB.Rows[i][DstTB.Columns[j].ColumnName];
                            }

                            break;

                        case DataRowState.Deleted:
                            for (int j = 0; j < DstTB.Columns.Count; j++)
                            {
                                tmpRow[DstTB.Columns[j].ColumnName] = SrcTB.Rows[i][DstTB.Columns[j].ColumnName, DataRowVersion.Original];
                            }
                            DstTB.Rows.Add(tmpRow);
                            tmpRow.AcceptChanges();
                            tmpRow.Delete();
                            break;
                    }
                }
                RjDs.Tables.Add(DstTB);
            }
            return RjDs;
        }
        //Bytes 转化为 DataSet
        public DataSet BytesToDataset(byte[] bArrayResult)
        {
            DataSet dsResult = null;
            MemoryStream ms = new MemoryStream(bArrayResult);
            IFormatter bf = new BinaryFormatter();
            try
            {
                object obj = bf.Deserialize(ms);
                dsResult = (DataSet)obj;
            }
            finally
            {
                ms.Close();
                ms.Dispose();
            }
            return dsResult;
        }
        //DataSet 转化为byte[]
        public byte[] DataSetToBytes(DataSet ds)
        {
            byte[] bArrayResult = null;
            ds.RemotingFormat = SerializationFormat.Binary;
            MemoryStream ms = new MemoryStream();
            IFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(ms, ds);
                bArrayResult = ms.ToArray();
            }
            finally
            {
                ms.Close();
                ms.Dispose();
            }
            return bArrayResult;
        }
        #endregion

    }
}