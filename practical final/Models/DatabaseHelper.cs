using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace practical_final.Models
{
    public class DatabaseHelper
    {
        private SQLiteConnection conn;

        // 构造函数：自动读取 Web.config 的数据库字符串
        public DatabaseHelper()
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
            conn = new SQLiteConnection(cs);
        }

        // 执行查询（返回 DataTable） - 实例方法
        public DataTable Query(string sql)
        {
            conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        // 执行查询（返回 DataTable） - 静态方法
        public static DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(cs))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 执行增删改 - 实例方法
        public void Execute(string sql)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // 执行增删改 - 静态方法
        public static int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(cs))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 执行查询返回单个值 - 静态方法
        public static object ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(cs))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}