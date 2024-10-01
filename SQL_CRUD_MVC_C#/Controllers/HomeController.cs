using Microsoft.AspNetCore.Mvc;
using SQL_CRUD_MVC_C_.Data;
using SQL_CRUD_MVC_C_.Models;
using System.Diagnostics;

namespace SQL_CRUD_MVC_C_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoDbContext _toDoDbContext;

        public HomeController(ILogger<HomeController> logger, ToDoDbContext toDoDbContext)
        {
            _logger = logger;
            _toDoDbContext = toDoDbContext;
        }

        public IActionResult Index()
        {
            return View(_toDoDbContext.ToDoItems.ToList());
        }

        [Route ("GetDetails")]
        [HttpGet("{id}")]
        public IActionResult GetDetails(int id) 
        {
            var item = _toDoDbContext.ToDoItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View("Details", item);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
