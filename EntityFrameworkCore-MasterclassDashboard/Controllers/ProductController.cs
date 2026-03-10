using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using X.PagedList.Extensions;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class ProductController : Controller
    {
        private readonly MasterclassContext _context;

        public ProductController(MasterclassContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            var values = _context.Products.Include(x=>x.Category).OrderBy(x=>x.Id).ToPagedList(pageNumber, 10);

            ViewBag.totalProduct = _context.Products.Count().ToString("N0");
            ViewBag.totalStock = _context.Products.Sum(x=>x.ProductStock).ToString("N0");
            ViewBag.avgPrice = _context.Products.Average(x => x.ProductPrice).ToString("N2");
            return View(values);
        }

        public IActionResult CreateProduct()
        {
            ViewBag.categoryList = new SelectList(_context.Categories.ToList(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            ViewBag.categoryList = new SelectList(_context.Categories.ToList(), "Id", "CategoryName");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateProduct(int id)
        {
            var values = _context.Products.Find(id);
            ViewBag.categoryList = new SelectList(_context.Categories.ToList(), "Id", "CategoryName", values.CategoryId);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            ViewBag.categoryList = new SelectList(_context.Categories.ToList(), "Id", "CategoryName");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _context.Products.Find(id);
            _context.Products.Remove(values);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
