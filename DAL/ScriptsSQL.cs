using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DAL
{
    public class ScriptsSQL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        int resultInt = 0;
        string result = "";

        public int AddScriptFile(Scripts scripts)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = "AddScriptFile";
                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", scripts.Name);
                cmd.Parameters.AddWithValue("@PhySicalPath", scripts.PhySicalPath);
                cmd.Parameters.AddWithValue("@ServerPath", scripts.ServerPath);

                resultInt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CommonSQL.AddLogToDB(ex);
                throw;
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection, cmd);
            }
            return resultInt;
        }

        public Scripts GetScriptFileByID(int ID)
        {
            Scripts script = new Scripts();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = "GetScriptFileByID";
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        script.ID = Convert.ToInt32(reader["ID"]);
                        script.Name = Convert.ToString(reader["Name"]);
                        script.PhySicalPath = Convert.ToString(reader["PhySicalPath"]);
                        script.ServerPath = Convert.ToString(reader["ServerPath"]);
                        script.Query = Convert.ToString(reader["Query"]);
                        DateTime dateTime = Convert.ToDateTime(reader["CreatedAT"]);
                        script.CreatedAT = dateTime.Date == Convert.ToDateTime("1753-01-01").Date ? "-" : Convert.ToDateTime(dateTime).ToString("f");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonSQL.AddLogToDB(ex);
                throw;
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection, cmd);
            }
            return script;
        }

        public List<Scripts> GetAllScriptFile()
        {
            List<Scripts> scripts = new List<Scripts>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = "GetAllScriptFile";
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Scripts script = new Scripts();
                        script.ID = Convert.ToInt32(reader["ID"]);
                        script.Name = Convert.ToString(reader["Name"]);
                        script.PhySicalPath = Convert.ToString(reader["PhySicalPath"]);
                        script.ServerPath = Convert.ToString(reader["ServerPath"]);
                        script.Query = Convert.ToString(reader["Query"]);
                        DateTime dateTime = Convert.ToDateTime(reader["CreatedAT"]);
                        script.CreatedAT = dateTime.Date == Convert.ToDateTime("1753-01-01").Date ? "-" : Convert.ToDateTime(dateTime).ToString("f");
                        scripts.Add(script);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonSQL.AddLogToDB(ex);
                throw;
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection, cmd);
            }
            return scripts;
        }

        public int DeleteScriptFile(int ID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = "DeleteScriptFile";
                cmd.Connection = connection;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);

                resultInt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CommonSQL.AddLogToDB(ex);
                throw;
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection, cmd);
            }
            return resultInt;
        }

        public bool TestConnection(SqlServer sql)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                if (sql.Authentication == "1")
                {
                    connection.ConnectionString = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True;", sql.ServerName);
                }
                else if (sql.Authentication == "2")
                {
                    connection.ConnectionString = string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2}", sql.ServerName, sql.UserName, sql.Password);
                }
                
                connection.Open();
            }
            catch (Exception ex)
            {
                CommonSQL.AddLogToDB(ex);
                return false;
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection);
            }
            return true;
        }

        public List<ListItem> GetAllDataBase(SqlServer sql)
        {
            List<ListItem> listDBName = new List<ListItem>();
           
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            
            if (sql.Authentication == "1")
            {
                connection.ConnectionString = string.Format("Data Source={0};Initial Catalog=MultipleDBChangesTool;Integrated Security=True;", sql.ServerName);
            }
            else if (sql.Authentication == "2")
            {
                connection.ConnectionString = string.Format("Data Source={0};Initial Catalog=MultipleDBChangesTool;User ID={1};Password={2}", sql.ServerName, sql.UserName, sql.Password);
            }
            
            try
            {
                connection.Open();
                cmd.CommandText = "GetAllDataBase";
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        ListItem db = new ListItem();
                        db.Text = Convert.ToString(reader["DBName"]);
                        db.Value = Convert.ToString(reader["DBCredentials"]);
                        listDBName.Add(db);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonSQL.AddLogToDB(ex);
                throw;
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection, cmd);
            }
            return listDBName;
        }

        public string ExecuteScript(SqlServer sql, string script)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            SqlTransaction transaction = null;
            try
            {
                if (sql.Authentication == "1")
                {
                    connection.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", sql.ServerName, sql.DataBaseName);
                }
                else if (sql.Authentication == "2")
                {
                    connection.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", sql.ServerName, sql.DataBaseName, sql.UserName, sql.Password);
                }
                connection.Open();
                transaction = connection.BeginTransaction();
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                string[] commandTexts = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string commandText in commandTexts)
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                result = "Success: " + sql.DataBaseName;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("multi-statement transaction"))
                {
                    string[] commandTexts = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string commandText in commandTexts)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = commandText;

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    result = "Failed: " + sql.DataBaseName;
                    CommonSQL.AddLogToDB(ex);
                    transaction.Rollback();
                }
            }
            finally
            {
                CommonSQL.ForceConnectionClose(connection, cmd);
            }
            return result;
        }
    }
}
