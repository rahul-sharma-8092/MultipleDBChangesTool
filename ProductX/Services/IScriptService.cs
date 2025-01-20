using ProductX.Models;

namespace ProductX.Services
{
    public interface IScriptService
    {
        Task<int> AddScriptFileAsync(Script script);
        Task<Script> GetScriptFileByIDAsync(int ID);
        Task<List<Script>> GetAllScriptFileAsync();
        Task<int> DeleteScriptFileAsync(int ID);
        Task<bool> TestConnectionAsync(Database dbobj);
    }
}
