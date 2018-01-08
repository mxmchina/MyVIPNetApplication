using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace UnitTestProject1
{
    public class DbHelper : IDisposable
    {
        private static string dbProviderName = "System.Data.SqlClient";
        /// <summary>
        /// 数据库连接字符串 
        /// </summary>
        public static string dbConnectionString = "";

        private DbConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbHelper"/> class.
        /// </summary>
        public DbHelper()
        {
            this.connection = CreateConnection(DbHelper.dbConnectionString);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbHelper"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DbHelper(string connectionString)
        {
            this.connection = CreateConnection(connectionString);
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns></returns>
        public static DbConnection CreateConnection()
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbConnection dbconn = dbfactory.CreateConnection();
            dbconn.ConnectionString = DbHelper.dbConnectionString;
            return dbconn;
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        public static DbConnection CreateConnection(string connectionString)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbConnection dbconn = dbfactory.CreateConnection();
            dbconn.ConnectionString = connectionString;
            return dbconn;
        }

        /// <summary>
        /// Gets the stored proc commond.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns></returns>
        public DbCommand GetStoredProcCommond(string storedProcedure)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = storedProcedure;
            dbCommand.CommandType = CommandType.StoredProcedure;
            return dbCommand;
        }

        /// <summary>
        /// Gets the SQL string commond.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <returns></returns>
        public DbCommand GetSqlStringCommond(string sqlQuery)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            dbCommand.CommandType = CommandType.Text;
            return dbCommand;
        }

        #region 增加参数
        /// <summary>
        /// Adds the parameter collection.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="dbParameterCollection">The db parameter collection.</param>
        public void AddParameterCollection(DbCommand cmd, DbParameterCollection dbParameterCollection)
        {
            foreach (DbParameter dbParameter in dbParameterCollection)
            {
                cmd.Parameters.Add(dbParameter);
            }
        }

        /// <summary>
        /// Adds the out parameter.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="size">The size.</param>
        public void AddOutParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Size = size;
            dbParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dbParameter);
        }

        /// <summary>
        /// Adds the in parameter.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="value">The value.</param>
        public void AddInParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            dbParameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(dbParameter);
        }

        /// <summary>
        /// Adds the return parameter.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        public void AddReturnParameter(DbCommand cmd, string parameterName, DbType dbType)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(dbParameter);
        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns></returns>
        public DbParameter GetParameter(DbCommand cmd, string parameterName)
        {
            return cmd.Parameters[parameterName];
        }

        #endregion

        #region 执行
        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataSet(DbCommand cmd, int pageNumber, int pageSize)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            int startRecord = (pageNumber - 1) * pageSize;
            int maxRecords = pageSize;
            dbDataAdapter.Fill(ds, startRecord, maxRecords, "table");
            return ds;
        }

        public DataSet ExecuteDataSet(string sqlQuery, int pageNumber, int pageSize)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DbCommand cmd = GetSqlStringCommond(sqlQuery);
            dbDataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            int startRecord = (pageNumber - 1) * pageSize;
            int maxRecords = pageSize;
            dbDataAdapter.Fill(ds, startRecord, maxRecords, "table");
            return ds;
        }

        /// <summary>
        /// Executes the data table.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(DbCommand cmd)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dbDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable ExecuteDataTable(DbCommand cmd, int pageNumber, int pageSize)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            int startRecord = (pageNumber - 1) * pageSize;
            int maxRecords = pageSize;
            dbDataAdapter.Fill(startRecord, maxRecords, dataTable);
            return dataTable;
        }

        public DataTable ExecuteDataTable(string sqlQuery, int pageNumber, int pageSize)
        {
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            DbCommand cmd = GetSqlStringCommond(sqlQuery);
            dbDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            int startRecord = (pageNumber - 1) * pageSize;
            int maxRecords = pageSize;
            dbDataAdapter.Fill(startRecord, maxRecords, dataTable);
            return dataTable;
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            cmd.Connection.Open();
            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand cmd)
        {
            cmd.Connection.Open();
            int ret = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ret;
        }

        public int ExecuteNonQuery(string sqlQuery)
        {
            DbCommand cmd = GetSqlStringCommond(sqlQuery);
            cmd.Connection.Open();
            int ret = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return ret;
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand cmd)
        {
            cmd.Connection.Open();
            object ret = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return ret;
        }

        public object ExecuteScalar(string sqlQuery)
        {
            DbCommand cmd = GetSqlStringCommond(sqlQuery);
            cmd.Connection.Open();
            object ret = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return ret;
        }
        #endregion

        #region 执行事务
        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand cmd, Trans t)
        {
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Executes the data table.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(DbCommand cmd, Trans t)
        {
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbProviderFactory dbfactory = DbProviderFactories.GetFactory(DbHelper.dbProviderName);
            DbDataAdapter dbDataAdapter = dbfactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dbDataAdapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            return reader;
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            int ret = cmd.ExecuteNonQuery();
            return ret;
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            object ret = cmd.ExecuteScalar();
            return ret;
        }
        #endregion

        public void Dispose()
        {
            this.Colse();
        }

        /// <summary>
        /// Colses this instance.
        /// </summary>
        public void Colse()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// Trans
    /// </summary>
    public class Trans : IDisposable
    {
        private DbConnection conn;
        private DbTransaction dbTrans;

        /// <summary>
        /// Gets the db connection.
        /// </summary>
        /// <value>The db connection.</value>
        public DbConnection DbConnection
        {
            get
            {
                return this.conn;
            }
        }

        /// <summary>
        /// Gets the db trans.
        /// </summary>
        /// <value>The db trans.</value>
        public DbTransaction DbTrans
        {
            get
            {
                return this.dbTrans;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trans"/> class.
        /// </summary>
        public Trans()
        {
            conn = DbHelper.CreateConnection();
            conn.Open();
            dbTrans = conn.BeginTransaction();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trans"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public Trans(string connectionString)
        {
            conn = DbHelper.CreateConnection(connectionString);
            conn.Open();
            dbTrans = conn.BeginTransaction();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            dbTrans.Commit();
            this.Colse();
        }

        /// <summary>
        /// Rolls the back.
        /// </summary>
        public void RollBack()
        {
            dbTrans.Rollback();
            this.Colse();
        }

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            this.Colse();
        }

        /// <summary>
        /// Colses this instance.
        /// </summary>
        public void Colse()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Close();
                }
                catch
                {

                }
            }
        }
    }
}

#region 调用实例

//1)直接执行sql语句
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetSqlStringCommond("insert t1 (id)values('haha')");
//         db.ExecuteNonQuery(cmd);
//2)执行存储过程
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetStoredProcCommond("t1_insert");
//         db.AddInParameter(cmd, "@id", DbType.String, "heihei");
//         db.ExecuteNonQuery(cmd);
//3)返回DataSet
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetSqlStringCommond("select * from t1");
//         DataSet ds = db.ExecuteDataSet(cmd);
//4)返回DataTable
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetSqlStringCommond("t1_findall");
//         DataTable dt = db.ExecuteDataTable(cmd);
//5)输入参数/输出参数/返回值的使用(比较重要)
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetStoredProcCommond("t2_insert");
//         db.AddInParameter(cmd, "@timeticks", DbType.Int64, DateTime.Now.Ticks);
//         db.AddOutParameter(cmd, "@outString", DbType.String, 20);
//         db.AddReturnParameter(cmd, "@returnValue", DbType.Int32);

//         db.ExecuteNonQuery(cmd);

//         string s = db.GetParameter(cmd, "@outString").Value as string;//out parameter
//         int r = Convert.ToInt32(db.GetParameter(cmd, "@returnValue").Value);//return value

//6)DataReader使用
//       DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetStoredProcCommond("t2_insert");
//         db.AddInParameter(cmd, "@timeticks", DbType.Int64, DateTime.Now.Ticks);
//         db.AddOutParameter(cmd, "@outString", DbType.String, 20);
//         db.AddReturnParameter(cmd, "@returnValue", DbType.Int32);

//         using (DbDataReader reader = db.ExecuteReader(cmd))
//          {
//             dt.Load(reader);
//         }        
//         string s = db.GetParameter(cmd, "@outString").Value as string;//out parameter
//         int r = Convert.ToInt32(db.GetParameter(cmd, "@returnValue").Value);//return value


//7)事务的使用.(项目中需要将基本的数据库操作组合成一个完整的业务流时,代码级的事务是必不可少的哦)
//     pubic void DoBusiness()
//      {
//         using (Trans t = new Trans())
//          {
//             try
//              {
//                 D1(t);
//                 throw new Exception();//如果有异常,会回滚滴
//                 D2(t);
//                 t.Commit();
//             }
//             catch
//              {
//                 t.RollBack();
//             }
//         }
//     }
//     public void D1(Trans t)
//      {
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetStoredProcCommond("t2_insert");
//         db.AddInParameter(cmd, "@timeticks", DbType.Int64, DateTime.Now.Ticks);
//         db.AddOutParameter(cmd, "@outString", DbType.String, 20);
//         db.AddReturnParameter(cmd, "@returnValue", DbType.Int32);

//         if (t == null) db.ExecuteNonQuery(cmd);
//         else db.ExecuteNonQuery(cmd,t);

//         string s = db.GetParameter(cmd, "@outString").Value as string;//out parameter
//         int r = Convert.ToInt32(db.GetParameter(cmd, "@returnValue").Value);//return value
//     }
//     public void D2(Trans t)
//      {
//         DbHelper db = new DbHelper();
//         DbCommand cmd = db.GetSqlStringCommond("insert t1 (id)values(' ..')");        
//         if (t == null) db.ExecuteNonQuery(cmd);
//         else db.ExecuteNonQuery(cmd, t);
//     }

//以上我们好像没有指定数据库连接字符串,大家如果看下DbHelper的代码,就知道要使用它必须在config中配置两个参数,如下:
//     <appSettings>
//         <add key="DbHelperProvider" value="System.Data.SqlClient"/>
//         <add key="DbHelperConnectionString" value="Data Source=(local);Initial Catalog=DbHelperTest;Persist Security Info=True;User ID=sa;Password=sa"/>
//     </appSettings>

#endregion