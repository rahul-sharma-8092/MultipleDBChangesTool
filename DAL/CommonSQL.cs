using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class CommonSQL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public static void AddLogToDB(LogTable log)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = "AddLogToDB";
                cmd.Connection = connection;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LogType", log.LogType);
                cmd.Parameters.AddWithValue("@Message", log.Message);
                cmd.Parameters.AddWithValue("@StackTrace", log.StackTrace);
                cmd.Parameters.AddWithValue("@InnerException", log.InnerException);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ForceConnectionClose(connection, cmd);
            }
        }

        public static void AddLogToDB(Exception ex, int logType = 1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = "AddLogToDB";
                cmd.Connection = connection;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LogType", logType);
                cmd.Parameters.AddWithValue("@Message", ex.Message);
                cmd.Parameters.AddWithValue("@StackTrace", ex.StackTrace);
                cmd.Parameters.AddWithValue("@InnerException", Convert.ToString(ex.InnerException));

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                ForceConnectionClose(connection, cmd);
            }
        }

        static public void ForceConnectionClose(SqlConnection connection, SqlCommand command)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
            command.Dispose();
        }

        static public void ForceConnectionClose(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
        }
    }
}
