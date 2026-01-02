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

       
        public DatabaseHelper()
        {
            string cs = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
            conn = new SQLiteConnection(cs);
        }

        
        public DataTable Query(string sql)
        {
            conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        
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

        
        public void Execute(string sql)
        {
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        
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