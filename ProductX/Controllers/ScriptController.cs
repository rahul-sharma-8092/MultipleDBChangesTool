using Microsoft.AspNetCore.Mvc;
using ProductX.Models;
using ProductX.Services;

namespace ProductX.Controllers
{
    [Route("Script")]
    public class ScriptController : Controller
    {
        public readonly IScriptService scriptService;
        public ScriptController(IScriptService _scriptService)
        {
            scriptService = _scriptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult AddScript()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddScript(Script scriptObj)
        {
            if (ModelState.IsValid)
            {
                var result = await scriptService.AddScriptFileAsync(scriptObj);
            }
            return View();
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ListScript()
        {
            var lstScript = await scriptService.GetAllScriptFileAsync();
            return View(lstScript);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteScript(string id)
        {
            var result = await scriptService.DeleteScriptFileAsync(Convert.ToInt32(id));
            return View();
        }

        [HttpGet]
        [Route("Execute/{id}")]
        public async Task<IActionResult> ExecuteScript(string id)
        {

            return View();
        }

        [HttpGet]
        [Route("Preview/{id}")]
        public async Task<IActionResult> PreviewScript(string id)
        {
            var script = await scriptService.GetScriptFileByIDAsync(Convert.ToInt32(id));
            return View(script);
        }
    }
}
