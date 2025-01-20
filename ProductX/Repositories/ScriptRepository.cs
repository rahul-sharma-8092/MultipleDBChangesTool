using Microsoft.Data.SqlClient;
using ProductX.Models;

namespace ProductX.Repositories
{
    public class ScriptRepository : IScriptRepository
    {
        private readonly string? connString;
        public ScriptRepository(IConfiguration _configuration)
        {
            connString = _configuration.GetConnectionString("dbConnection");
        }

        async Task<int> IScriptRepository.AddScriptFileAsync(Script script)
        {
            using (var connection = new SqlConnection(connString))
            using (var cmd = new SqlCommand())
            {
                try
                {
                    await connection.OpenAsync();

                    cmd.Connection = connection;
                    cmd.CommandText = "AddScriptFile";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", script.Name);
                    cmd.Parameters.AddWithValue("@PhysicalPath", script.PhysicalPath);
                    cmd.Parameters.AddWithValue("@ServerPath", script.ServerPath);

                    return await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        async Task<int> IScriptRepository.DeleteScriptFileAsync(int Id)
        {
            using (var connection = new SqlConnection(connString))
            using (var cmd = new SqlCommand())
            {
                try
                {
                    await connection.OpenAsync();

                    cmd.Connection = connection;
                    cmd.CommandText = "DeleteScriptFile";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", Id);

                    return await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        async Task<List<Script>> IScriptRepository.GetAllScriptFileAsync()
        {
            List<Script> lstScript = new List<Script>();

            using (var connection = new SqlConnection(connString))
            using (var cmd = new SqlCommand())
            {
                try
                {
                    await connection.OpenAsync();

                    cmd.Connection = connection;
                    cmd.CommandText = "GetAllScriptFile";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if (reader.HasRows)
                            {
                                Script scriptObj = new Script();
                                scriptObj.Id = Convert.ToInt32(reader["Id"]);
                                scriptObj.Name = Convert.ToString(reader["Name"]);
                                scriptObj.PhysicalPath = Convert.ToString(reader["PhysicalPath"]);
                                scriptObj.ServerPath = Convert.ToString(reader["ServerPath"]);
                                scriptObj.CreatedAT = Convert.ToDateTime(reader["CreatedAT"]);

                                lstScript.Add(scriptObj);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return lstScript;
        }

        async Task<Script> IScriptRepository.GetScriptFileByIDAsync(int Id)
        {
            Script scriptObj = new Script();

            using (var connection = new SqlConnection(connString))
            using (var cmd = new SqlCommand())
            {
                try
                {
                    await connection.OpenAsync();

                    cmd.Connection = connection;
                    cmd.CommandText = "GetScriptFileById";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if (reader.HasRows)
                            {
                                scriptObj.Id = Convert.ToInt32(reader["Id"]);
                                scriptObj.Name = Convert.ToString(reader["Name"]);
                                scriptObj.PhysicalPath = Convert.ToString(reader["PhysicalPath"]);
                                scriptObj.ServerPath = Convert.ToString(reader["ServerPath"]);
                                scriptObj.CreatedAT = Convert.ToDateTime(reader["CreatedAT"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return scriptObj;
        }

        Task<bool> IScriptRepository.TestConnectionAsync(Database dbobj)
        {
            throw new NotImplementedException();
        }
    }
}
