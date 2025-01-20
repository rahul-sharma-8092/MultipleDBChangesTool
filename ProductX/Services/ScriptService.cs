using ProductX.Models;
using ProductX.Repositories;

namespace ProductX.Services
{
    public class ScriptService : IScriptService
    {
        private readonly IScriptRepository scriptRepository;
        public ScriptService(IScriptRepository _scriptRepository)
        {
            scriptRepository = _scriptRepository;
        }

        async Task<int> IScriptService.AddScriptFileAsync(Script script)
        {
            return await scriptRepository.AddScriptFileAsync(script);
        }

        async Task<int> IScriptService.DeleteScriptFileAsync(int Id)
        {
            return await scriptRepository.DeleteScriptFileAsync(Id);
        }

        async Task<List<Script>> IScriptService.GetAllScriptFileAsync()
        {
            return await scriptRepository.GetAllScriptFileAsync();
        }

        async Task<Script> IScriptService.GetScriptFileByIDAsync(int Id)
        {
            return await scriptRepository.GetScriptFileByIDAsync(Id);
        }

        async Task<bool> IScriptService.TestConnectionAsync(Database dbobj)
        {
            return await scriptRepository.TestConnectionAsync(dbobj);
        }
    }
}
