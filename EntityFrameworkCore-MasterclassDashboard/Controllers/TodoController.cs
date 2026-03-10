using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class TodoController : Controller
    {
        private readonly MasterclassContext _context;

        public TodoController(MasterclassContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.todoList = _context.Todos.ToList();
            ViewBag.highPriorityTask = _context.Todos.Where(x => x.Priority == "Yüksek").ToList();
            ViewBag.medPriorityTask = _context.Todos.Where(x => x.Priority == "Orta").ToList();
            ViewBag.lowPriorityTask = _context.Todos.Where(x => x.Priority == "Düşük").ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var todo = _context.Todos.Find(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
