using Microsoft.AspNetCore.Mvc;
using ProductX.Models;

namespace ProductX.Controllers
{
    [Route("Script")]
    public class ScriptController : Controller
    {
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
        public IActionResult AddScript(Script scriptObj)
        {
            return View();
        }

        [HttpGet]
        [Route("List")]
        public IActionResult ListScript()
        {
            return View();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteScript(string id)
        {
            return View();
        }

        [HttpGet]
        [Route("Execute")]
        public IActionResult ExecuteScript()
        {
            return View();
        }

        [HttpGet]
        [Route("Preview")]
        public IActionResult PreviewScript()
        {
            return View();
        }
    }
}
