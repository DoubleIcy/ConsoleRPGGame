//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using System.Data.Common;
//using System.Data.Sql;
//using System.Data.Odbc;
//using System.Data.SqlTypes;
//using System.Data.SqlClient;
//using System.Data.SqlServerCe;
//using System.Data.ProviderBase;
//using System.Data.OleDb;
//using System.IO;
//using System.Reflection;
//using System.Security;
//using System.Security.Permissions;
//using System.Security.Authentication;
//namespace Bas.dll
//{ 
//    /// <summary>  
//    /// 超级数据库操作类  
//    /// <para>2015年12月21日</para>  
//    /// </summary>  
//    public class DBHelper
//    {
//        #region 属性
//        private DbProviderFactory _DbFactory;
//        private DBConfig mDBConfig;

//        /// <summary>  
//        /// 数据库连接配置  
//        /// </summary>  
//        public DBConfig DBConfig
//        {
//            get { return mDBConfig; }
//        }

//        /// <summary>  
//        /// 表示一组方法，这些方法用于创建提供程序对数据源类的实现的实例。  
//        /// </summary>  
//        public DbProviderFactory DbFactory
//        {
//            get { return _DbFactory; }
//            set { _DbFactory = value; }
//        }
//        #endregion

//        #region 构造函数
//        public DBHelper(DBConfig aORMConfig)
//        {
//            mDBConfig = aORMConfig;
//            switch (mDBConfig.DBType)
//            {
//                case "ORMType.DBTypes.SQLSERVER":
//                    _DbFactory = System.Data.SqlClient.SqlClientFactory.Instance;
//                    break;
//                case "ORMType.DBTypes.MYSQL":
//                    LoadDbProviderFactory("MySql.Data.dll", "MySql.Data.MySqlClient.MySqlClientFactory");
//                    break;
//                case "ORMType.DBTypes.SQLITE":
//                    LoadDbProviderFactory("System.Data.SQLite.dll", "System.Data.SQLite.SQLiteFactory");
//                    break;
//            }
//        }

//        /// <summary>  
//        /// 动态载入数据库封装库  
//        /// </summary>  
//        /// <param name="aDLLName">数据库封装库文件名称</param>  
//        /// <param name="aFactoryName">工厂路径名称</param>  
//        private void LoadDbProviderFactory(string aDLLName, string aFactoryName)
//        {
//            string dllPath = string.Empty;
//            if (System.AppDomain.CurrentDomain.RelativeSearchPath != null)
//            {
//                dllPath = System.AppDomain.CurrentDomain.RelativeSearchPath + "\\" + aDLLName;
//            }
//            else
//            {
//                dllPath = System.AppDomain.CurrentDomain.BaseDirectory + aDLLName;
//            }
//            if (!File.Exists(dllPath))
//            {//文件不存在，从库资源中复制输出到基目录下  
//                FileStream fdllFile = new FileStream(dllPath, FileMode.Create);
//                byte[] dllData = null;
//                if (aDLLName == "System.Data.SQLite.dll")
//                {
//                    dllData = YFmk.ORM.Properties.Resources.System_Data_SQLite;
//                }
//                else if (aDLLName == "MySql.Data.dll")
//                {
//                    dllData = YFmk.ORM.Properties.Resources.MySql_Data;
//                }
//                fdllFile.Write(dllData, 0, dllData.Length);
//                fdllFile.Close();
//            }
//            Assembly libAssembly = Assembly.LoadFile(dllPath);
//            Type type = libAssembly.GetType(aFactoryName);
//            foreach (FieldInfo fi in type.GetFields(BindingFlags.Static | BindingFlags.Public))
//            {
//                if (fi.Name == "Instance")
//                {
//                    _DbFactory = fi.GetValue(null) as DbProviderFactory;
//                    return;
//                }
//            }
//        }
//        #endregion

//        #region 数据库操作
//        /// <summary>  
//        /// 执行一条计算查询结果语句，返回查询结果  
//        /// </summary>  
//        /// <param name="aSQLWithParameter">SQL语句及参数</param>  
//        /// <returns>查询结果（object）</returns>  
//        public object GetSingle(SQLWithParameter aSQLWithParameter)
//        {
//            using (DbConnection conn = _DbFactory.CreateConnection())
//            {
//                conn.ConnectionString = mDBConfig.ConnString;
//                using (DbCommand cmd = _DbFactory.CreateCommand())
//                {
//                    PrepareCommand(cmd, conn, aSQLWithParameter.SQL.ToString(), aSQLWithParameter.Parameters);
//                    object obj = cmd.ExecuteScalar();
//                    cmd.Parameters.Clear();
//                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
//                    {
//                        return null;
//                    }
//                    else
//                    {
//                        return obj;
//                    }
//                }
//            }
//        }

//        /// <summary>  
//        /// 执行SQL语句，返回影响的记录数  
//        /// </summary>  
//        /// <param name="aSQL">SQL语句</param>  
//        /// <returns>影响的记录数</returns>  
//        public int ExecuteSql(string aSQL)
//        {
//            using (DbConnection conn = _DbFactory.CreateConnection())
//            {
//                conn.ConnectionString = mDBConfig.ConnString;
//                using (DbCommand cmd = _DbFactory.CreateCommand())
//                {
//                    PrepareCommand(cmd, conn, aSQL);
//                    int rows = cmd.ExecuteNonQuery();
//                    cmd.Parameters.Clear();
//                    return rows;
//                }
//            }
//        }

//        /// <summary>  
//        /// 执行SQL语句，返回影响的记录数  
//        /// </summary>  
//        /// <param name="aSQLWithParameter">SQL语句及参数</param>  
//        /// <returns></returns>  
//        public int ExecuteSql(SQLWithParameter aSQLWithParameter)
//        {
//            using (DbConnection conn = _DbFactory.CreateConnection())
//            {
//                conn.ConnectionString = mDBConfig.ConnString;
//                using (DbCommand cmd = _DbFactory.CreateCommand())
//                {
//                    PrepareCommand(cmd, conn, aSQLWithParameter.SQL.ToString(), aSQLWithParameter.Parameters);
//                    int rows = cmd.ExecuteNonQuery();
//                    cmd.Parameters.Clear();
//                    return rows;
//                }
//            }
//        }

//        /// <summary>  
//        /// 执行多条SQL语句，实现数据库事务。  
//        /// </summary>  
//        /// <param name="aSQLWithParameterList">参数化的SQL语句结构体对象集合</param>          
//        public string ExecuteSqlTran(List<SQLWithParameter> aSQLWithParameterList)
//        {
//            using (DbConnection conn = _DbFactory.CreateConnection())
//            {
//                conn.ConnectionString = mDBConfig.ConnString;
//                conn.Open();
//                DbTransaction fSqlTransaction = conn.BeginTransaction();
//                try
//                {
//                    List<DbCommand> fTranCmdList = new List<DbCommand>();
//                    //创建新的CMD  
//                    DbCommand fFirstCMD = _DbFactory.CreateCommand();
//                    fFirstCMD.Connection = conn;
//                    fFirstCMD.Transaction = fSqlTransaction;
//                    fTranCmdList.Add(fFirstCMD);
//                    int NowCmdIndex = 0;//当前执行的CMD索引值  
//                    int ExecuteCount = 0;//已经执行的CMD次数  
//                    StringBuilder fSQL = new StringBuilder();
//                    foreach (SQLWithParameter fSQLWithParameter in aSQLWithParameterList)
//                    {
//                        fSQL.Append(fSQLWithParameter.SQL.ToString() + ";");
//                        fTranCmdList[NowCmdIndex].Parameters.AddRange(fSQLWithParameter.Parameters.ToArray());
//                        if (fTranCmdList[NowCmdIndex].Parameters.Count > 2000)
//                        { //参数达到2000个，执行一次CMD  
//                            fTranCmdList[NowCmdIndex].CommandText = fSQL.ToString();
//                            fTranCmdList[NowCmdIndex].ExecuteNonQuery();
//                            DbCommand fNewCMD = _DbFactory.CreateCommand();
//                            fNewCMD.Connection = conn;
//                            fNewCMD.Transaction = fSqlTransaction;
//                            fTranCmdList.Add(fNewCMD);
//                            NowCmdIndex++;
//                            ExecuteCount++;
//                            fSQL = new StringBuilder();// fSQL.Clear();//清空SQL  
//                        }
//                    }
//                    if (ExecuteCount < fTranCmdList.Count)
//                    {//已执行CMD次数小于总CMD数，执行最后一条CMD  
//                        fTranCmdList[fTranCmdList.Count - 1].CommandText = fSQL.ToString();
//                        fTranCmdList[fTranCmdList.Count - 1].ExecuteNonQuery();
//                    }
//                    fSqlTransaction.Commit();
//                    return null;
//                }
//                catch (Exception ex)
//                {
//                    fSqlTransaction.Rollback();
//                    StringBuilder fSQL = new StringBuilder();
//                    foreach (SQLWithParameter fSQLWithParameter in aSQLWithParameterList)
//                    {
//                        fSQL.Append(fSQLWithParameter.SQL.ToString() + ";");
//                    }
//                    YFmk.Lib.LocalLog.WriteByDate(fSQL.ToString() + " 错误：" + ex.Message, "ORM");
//                    return ex.Message;
//                }
//            }
//        }

//        /// <summary>  
//        /// 执行查询语句，返回DataSet  
//        /// </summary>  
//        /// <param name="SQLString">查询语句</param>  
//        /// <returns>DataSet</returns>  
//        public DataSet Query(string SQLString)
//        {
//            using (DbConnection conn = _DbFactory.CreateConnection())
//            {
//                conn.ConnectionString = mDBConfig.ConnString;
//                using (DbCommand cmd = _DbFactory.CreateCommand())
//                {
//                    PrepareCommand(cmd, conn, SQLString);
//                    using (DbDataAdapter da = _DbFactory.CreateDataAdapter())
//                    {
//                        da.SelectCommand = cmd;
//                        DataSet ds = new DataSet();
//                        try
//                        {
//                            da.Fill(ds, "ds");
//                            cmd.Parameters.Clear();
//                        }
//                        catch (Exception ex)
//                        {

//                        }
//                        return ds;
//                    }
//                }
//            }
//        }

//        /// <summary>  
//        /// 执行查询语句，返回DataSet  
//        /// </summary>  
//        /// <param name="aSQLWithParameter">查询语句</param>  
//        /// <returns>DataSet</returns>  
//        public DataSet Query(SQLWithParameter aSQLWithParameter)
//        {
//            using (DbConnection conn = _DbFactory.CreateConnection())
//            {
//                conn.ConnectionString = mDBConfig.ConnString;
//                using (DbCommand cmd = _DbFactory.CreateCommand())
//                {
//                    PrepareCommand(cmd, conn, aSQLWithParameter.SQL.ToString(), aSQLWithParameter.Parameters);
//                    using (DbDataAdapter da = _DbFactory.CreateDataAdapter())
//                    {
//                        da.SelectCommand = cmd;
//                        DataSet ds = new DataSet();
//                        da.Fill(ds, "ds");
//                        cmd.Parameters.Clear();
//                        return ds;
//                    }
//                }
//            }
//        }
//        #endregion

//        #region 私有函数
//        private void PrepareCommand(DbCommand cmd, DbConnection conn, string cmdText)
//        {
//            if (conn.State != ConnectionState.Open)
//                conn.Open();
//            cmd.Connection = conn;
//            cmd.CommandText = cmdText;
//        }

//        private void PrepareCommand(DbCommand cmd, DbConnection conn, string cmdText, List<DbParameter> cmdParms)
//        {
//            if (conn.State != ConnectionState.Open)
//                conn.Open();
//            cmd.Connection = conn;
//            cmd.CommandText = cmdText;
//            if (cmdParms != null && cmdParms.Count > 0)
//            {
//                cmd.Parameters.AddRange(cmdParms.ToArray());
//            }
//        }
//        #endregion


//    }

//}