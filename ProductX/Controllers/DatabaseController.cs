using Microsoft.AspNetCore.Mvc;

namespace ProductX.Controllers
{
    [Route("Database")]
    public class DatabaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult AddDatabase()
        {
            return View();
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public IActionResult DeleteDatabase(string id)
        {
            return View();
        }
    }
}
