using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;

namespace EmeManager
{
    public class WCFDoProxy:IDoProxy
    {
        #region IDoProxy 成员
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["AssemblyName"].ToString();

        public object DoProxy(string ClassName, string MethodName, object[] args)
        {
            if (args!=null)
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is DataSet)
                {
                    //args[i] = DataSetToBytes((DataSet)args[i]);
                    args[i] = DataSetToBytes(CopyDataSet((DataSet)args[i]));
                }
            }
            EmeManager.Proxy.RaykingEmeService.RaykingProxyClient ProxyClient = new EmeManager.Proxy.RaykingEmeService.RaykingProxyClient();
            ProxyClient.ClientCredentials.UserName.UserName = "matao";
            ProxyClient.ClientCredentials.UserName.Password = "654321";

            object obj = ProxyClient.DoProxy(AssemblyName, ClassName, MethodName, args);
            if (obj is byte[])
                obj = BytesToDataset((byte[])obj);
            return obj;
        }

        public DataTable DoProxyDataTable(string ClassName, string MethodName, object[] args)
        {
            return (DoProxy(ClassName, MethodName, args) as DataSet).Tables[0];
        }

        public DataSet DoProxyDataSet(string ClassName, string MethodName, object[] args)
        {
            return  (DataSet)DoProxy(ClassName, MethodName, args);
        }

        public void DoProxyNoResult(string ClassName, string MethodName, object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is DataSet)
                {
                    //args[i] = DataSetToBytes((DataSet)args[i]);
                    args[i] = DataSetToBytes(CopyDataSet((DataSet)args[i]));

                }
            }
            EmeManager.Proxy.RaykingEmeService.RaykingProxyClient ProxyClient = new EmeManager.Proxy.RaykingEmeService.RaykingProxyClient();
            ProxyClient.ClientCredentials.UserName.UserName = "matao";
            ProxyClient.ClientCredentials.UserName.Password = "654321";

            ProxyClient.DoProxy(AssemblyName, ClassName, MethodName, args);
        }

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
        public  DataSet BytesToDataset(byte[] bArrayResult)
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
        public  byte[] DataSetToBytes(DataSet ds)
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
