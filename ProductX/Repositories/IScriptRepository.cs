using ProductX.Models;

namespace ProductX.Repositories
{
    public interface IScriptRepository
    {
        Task<int> AddScriptFileAsync(Script script);
        Task<Script> GetScriptFileByIDAsync(int Id);
        Task<List<Script>> GetAllScriptFileAsync();
        Task<int> DeleteScriptFileAsync(int Id);
        Task<bool> TestConnectionAsync(Database dbobj);
    }
}
