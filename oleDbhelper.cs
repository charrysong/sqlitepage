using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
namespace access.connection
{
    public static class OleDbHelper
    {
        private static OleDbConnection connection;
        /// <summary>
        /// 获得一个唯一的CONNECTION 实例
        /// </summary>
        public static OleDbConnection Connection
        {
            get
            {
                string connectionstring = ConfigurationManager.AppSettings["database"].ToString();
                if (connection == null)
                {
                    connection = new OleDbConnection(connectionstring);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        /// 返回执行SQL 语句所影响数据的行数
        public static int ExecuteCommand(string sql)
        {
            DataSet dataset = new DataSet();
            OleDbCommand com = new OleDbCommand(sql, Connection);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            da.Fill(dataset);
            return dataset.Tables[0].Rows.Count;
        }
        /// 获取结果集的第一行第一列
        public static int GetScalar(string sql)
        {
            OleDbCommand com = new OleDbCommand(sql, Connection);
            int result = int.Parse(com.ExecuteScalar().ToString());
            return result;
        }
        /// 获得第数据
        public static DataTable GetDataSet(string sql)
        {
            DataSet dataset = new DataSet();
            OleDbCommand com = new OleDbCommand(sql, Connection);
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            da.Fill(dataset);
            return dataset.Tables[0];
        }
        public static OleDbDataReader GetReader(string sql)
        {
            OleDbCommand com = new OleDbCommand(sql, Connection);
            OleDbDataReader reader = com.ExecuteReader();
            return reader;
        }
    }
}
