using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using MySql.Data.MySqlClient;

namespace ASP.NET_Project_MySQL.Models
{
    public static class SQLControl
    {
        public static string cs(string cs_name = "constr")
        {
            return ConfigurationManager.ConnectionStrings[cs_name].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(cs()))
            {
                return cnn.Query<T>(sql).ToList();

            }

        }
        public static int ExecuteData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new MySqlConnection(cs()))
            {
                return cnn.Execute(sql, data);
            }

        }
    }
}