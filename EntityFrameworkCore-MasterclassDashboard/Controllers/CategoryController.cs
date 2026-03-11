using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MasterclassContext _context;

        public CategoryController(MasterclassContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page, string searchString)
        {
            var categories = _context.Categories
                .Include(x => x.Products)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
                categories = categories.Where(x => x.CategoryName.Contains(searchString));

            var model = categories.OrderBy(x => x.Id).ToPagedList(page ?? 1, 10);

            ViewBag.totalCategory   = _context.Categories.Count().ToString("N0");
            ViewBag.totalProduct    = _context.Products.Count().ToString("N0");
            var productCounts = _context.Categories
                .Include(x => x.Products)
                .ToList()
                .Select(x => x.Products.Count)
                .ToList();

            ViewBag.avgProductCount = productCounts.Average().ToString("N1");

            ViewBag.Search = searchString;

            return View(model);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateCategory(int id)
        {
            var values = _context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCategory(int id)
        {
            var values = _context.Categories.Find(id);
            _context.Categories.Remove(values);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
