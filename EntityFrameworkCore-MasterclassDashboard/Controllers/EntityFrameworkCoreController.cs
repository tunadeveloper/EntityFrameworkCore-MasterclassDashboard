using EntityFrameworkCore_MasterclassDashboard.Context;
using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_MasterclassDashboard.Controllers
{
    public class EntityFrameworkCoreController : Controller
    {
        private readonly MasterclassContext _context;

        public EntityFrameworkCoreController(MasterclassContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // ODEV 1 - ToList
            ViewBag.productList = _context.Products.ToList().Count();

            // ODEV 2 - Add & SaveChanges
            // ViewBag.addedProduct = ...   -> eklenen urun adi
            //var product = new Product
            //{
            //    ProductName = "24 inc Monitor",
            //    ProductPrice = 50,
            //    ProductStock = 70,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = null,
            //    IsActive = true,
            //    CategoryId = 2
            //};
            //_context.Products.Add(product);
            //_context.SaveChanges();
            //ViewBag.addedProduct = product.ProductName;

            // ODEV 3 - Find
            var findCustomer = _context.Customers.Find(10);
            ViewBag.findCustomer = $"{findCustomer.CustomeName} {findCustomer.CustomeSurname}";

            //// ODEV 4 - Remove & SaveChanges
            //var orderToRemove = _context.Orders.First();
            //_context.Orders.Remove(orderToRemove);
            //_context.SaveChanges();
            //ViewBag.removedOrder = $"Sipariş #{orderToRemove.Id} silindi";

            //// ODEV 5 - Update & SaveChanges
            //var productToUpdate = _context.Products.First();
            //var oldPrice = productToUpdate.ProductPrice;
            //productToUpdate.ProductPrice = 349;
            //_context.SaveChanges();
            //ViewBag.updatedProduct = $"Fiyat ₺{oldPrice} -> ₺{productToUpdate.ProductPrice}";

            // ODEV 6 - Count
            ViewBag.activeCount = _context.Products.Where(x => x.IsActive).Count();

            // ODEV 7 - Min
            ViewBag.lowPriceProduct = _context.Products.Select(x => x.ProductPrice).Min();

            // ODEV 8 - Max
            ViewBag.highBalanceCustomer = _context.Customers.Select(x => x.CustomeBalance).Max();

            // ODEV 9 - Sum
            ViewBag.totalCustomerBalance = _context.Customers.Sum(x => x.CustomeBalance);

            // ODEV 10 - Average
            ViewBag.avgProductStock = _context.Products.Average(x => x.ProductStock);

            // ODEV 11 - LongCount
            ViewBag.totalOrderLong = _context.Orders.LongCount();

            // ODEV 12 - CountBy
            ViewBag.productActiveGroups = _context.Products.ToList().CountBy(p => p.IsActive).ToList();

            // ODEV 13 - Where
            ViewBag.filteredProducts = _context.Products.Where(x => x.ProductStock > 50).Count();

            // ODEV 14 - Select
            ViewBag.orderSummary = _context.Orders.Select(x => x.IsActive).Count();

            // ODEV 15 - Include
            ViewBag.ordersWithDetails = _context.Orders.Include(x => x.Product).Include(x => x.Customer).Count();

            // ODEV 16 - FirstOrDefault
            ViewBag.firstExpensiveProduct = _context.Products.FirstOrDefault(x => x.ProductPrice < 1000).ProductName;

            // ODEV 17 - First
            ViewBag.firstCustomer = _context.Customers.First().CustomeName;

            // ODEV 18 - Last
            ViewBag.lastOrder = _context.Orders.OrderBy(x => x.Id).Last();

            // ODEV 19 - SingleOrDefault
            ViewBag.singleProduct = _context.Products.SingleOrDefault(x=>x.ProductName == "Akıllı Saat V2");

            // ODEV 20 - Any
            ViewBag.hasExpensiveOrder = _context.Orders.Any(x => x.TotalPrice > 5000);

            // ODEV 21 - All
            ViewBag.allProductsActive = _context.Products.All(x=>x.IsActive);

            // ODEV 22 - Contains
            ViewBag.containsHeadphone = _context.Products.Where(x => x.ProductName.Contains("USB")).Count();

            // ODEV 23 - StartsWith
            ViewBag.customersStartWithA = _context.Customers.Select(x => x.CustomeName.StartsWith("A")).Count();

            //ODEV 24 - EndsWith
            ViewBag.customersEndsWithI = _context.Customers.Select(x => x.CustomeCity.EndsWith("i")).Count();

            // ODEV 25 - AsQueryable
            var query = _context.Products.AsQueryable();
            query = query.Where(x => x.IsActive);
            ViewBag.queryableProducts = query.Count();

            // ODEV 26 - AsNoTracking
            ViewBag.noTrackingCategories = _context.Categories.AsNoTracking().Count();

            // ODEV 27 - DefaultIfEmpty
            ViewBag.defaultIfEmptyResult = _context.Products.Where(x => x.ProductPrice > 99999).Select(x => x.ProductName).AsEnumerable().DefaultIfEmpty("Sonuç Yok").FirstOrDefault();

            // ODEV 28 - OrderBy
            ViewBag.productsByPriceAsc = _context.Products.OrderBy(x => x.ProductPrice).Select(x=>x.ProductName).First();

            // ODEV 29 - OrderByDescending
            ViewBag.customersByBalanceDesc = _context.Customers.OrderByDescending(x => x.CustomeBalance).Select(x => x.CustomeName).First();

            // ODEV 30 - Take
            ViewBag.top5Products = _context.Products.OrderByDescending(x=>x.ProductPrice).Take(5).Select(x=>x.ProductName).First();

            // ODEV 31 - Skip
            ViewBag.skippedOrders = _context.Orders.OrderBy(x=>x.Id).Skip(10).Count();

            // ODEV 32 - TakeLast
            ViewBag.lastThreeProducts = _context.Products.OrderBy(X => X.Id).TakeLast(1).Select(x=>x.ProductName);

            // ODEV 33 - SkipLast
            ViewBag.skipLastProducts = _context.Orders.OrderBy(x => x.Id).AsEnumerable().SkipLast(5).Select(x => x.Id).Last();

            // ODEV 34 - Reverse
            ViewBag.reversedProducts = _context.Products.OrderBy(x => x.Id).Reverse().Select(x=>x.ProductName).First();

            // ODEV 35 - Chunk
            var allOrder = _context.Orders.ToList();
            ViewBag.chunkedOrders = allOrder.Chunk(10).FirstOrDefault().Count();

            // ODEV 36 - Index
            var products = _context.Products.AsNoTracking().ToList();

            // ODEV 36 - Index
            var indexedProducts = _context.Products.AsEnumerable().Select((p, index) => new { Index = index, p.ProductName }).ToList();
            ViewBag.indexedProducts = $"Index: 0 -> {indexedProducts.Count - 1}";

            // ODEV 37 - Distinct
            ViewBag.distinctCities = _context.Customers.Select(x => x.CustomeCity).Distinct().Count();

            // ODEV 38 - Union
            var cheapProducts = _context.Products.Where(x => x.ProductPrice < 100);
            var expensiveProducts = _context.Products.Where(x => x.ProductPrice > 900);
            ViewBag.unionProducts = cheapProducts.Union(expensiveProducts).Count();

            // ODEV 39 - UnionBy
            var activeProducts = _context.Products.Where(x => x.IsActive).AsEnumerable();
            var inStockProducts = _context.Products.Where(x => x.ProductStock > 0).AsEnumerable();
            ViewBag.unionByProducts = activeProducts.UnionBy(inStockProducts, x => x.Id).Count();

            // ODEV 40 - Concat
            var istCustomers = _context.Customers.Where(x => x.CustomeCity == "İstanbul");
            var ankCustomers = _context.Customers.Where(x => x.CustomeCity == "Ankara");
            ViewBag.concatCustomers = istCustomers.Concat(ankCustomers).Count();

            // ODEV 41 - Except
            var allProductNames = _context.Products.Select(x => x.ProductName);
            var inStockProductNames = _context.Products.Where(x => x.ProductStock > 0).Select(x => x.ProductName);
            ViewBag.exceptProducts = allProductNames.Except(inStockProductNames).Count();

            // ODEV 42 - ExceptBy
            var allOrders = _context.Orders.AsEnumerable();
            var expensiveOrderIds = _context.Orders.Where(x => x.TotalPrice > 1000).Select(x => x.Id).AsEnumerable();
            ViewBag.exceptByOrders = allOrders.ExceptBy(expensiveOrderIds, x => x.Id).Count();

            // ODEV 43 - Intersect
            ViewBag.intersectProducts = activeProducts.Intersect(inStockProducts).Count();

            // ODEV 44 - GroupBy
            ViewBag.groupedOrders = _context.Orders.GroupBy(x => x.CustomerId).Count();

            // ODEV 45 - GroupJoin
            var groupJoinCategories = _context.Categories.GroupJoin(_context.Products, c => c.Id, p => p.CategoryId, (c, pList) => new { Category = c, Products = pList });
            ViewBag.groupJoinResult = groupJoinCategories.Count();

            // ODEV 46 - Join
            var joinOrdersProducts = _context.Orders.Join(_context.Products, o => o.ProductId, p => p.Id, (o, p) => new { o.Id, p.ProductName, p.ProductPrice });
            ViewBag.joinResult = joinOrdersProducts.Count();

            // ODEV 47 - Append
            var appendedList = _context.Products.AsEnumerable().Append(new Product { ProductName = "Geçici Eklendi" });
            ViewBag.appendedList = appendedList.Count();

            // ODEV 48 - Prepend
            var prependedList = _context.Products.AsEnumerable().Prepend(new Product { ProductName = "Başa Eklendi" });
            ViewBag.prependedList = prependedList.Count();

            // ODEV 49 - Aggregate
            var productNames = _context.Products.Select(x => x.ProductName).Take(3).ToList();
            if (productNames.Any())
            {
                ViewBag.aggregatedNames = productNames.Aggregate((current, next) => current + ", " + next);
            }

            // ODEV 50 - Cast<T>
            var objectList = _context.Products.ToList<object>();
            ViewBag.castedProducts = objectList.Cast<Product>().Count();

            // ODEV 51 - OfType<T>
            var mixedList = new List<object> { "Test", 123, new Product() };
            ViewBag.ofTypeProducts = mixedList.OfType<Product>().Count();

            // ODEV 52 - AsParallel
            ViewBag.parallelProducts = _context.Products.AsEnumerable().AsParallel().Where(x => x.ProductPrice > 500).Count();

            // ODEV 53 - ToListAsync
            var asyncCustomersList = await _context.Customers.ToListAsync();
            ViewBag.asyncCustomers = asyncCustomersList.Count;

            // ODEV 54 - AddAsync & SaveChangesAsync
            var newCategory = new Category { CategoryName = "Yeni Kategori" };
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            ViewBag.asyncAddedCategory = newCategory.CategoryName;

            // ODEV 55 - FindAsync
            var asyncOrder = await _context.Orders.FindAsync(1);
            ViewBag.asyncFoundOrder = asyncOrder != null ? $"Sipariş No: {asyncOrder.Id}" : "Bulunamadı";

            // ODEV 56 - AddRange
            _context.Products.AddRange(
                new Product { ProductName = "Urun A", CategoryId = 1 },
                new Product { ProductName = "Urun B", CategoryId = 1 },
                new Product { ProductName = "Urun C", CategoryId = 1 }
            );
            _context.SaveChanges();
            ViewBag.addRangeResult = "3 ürün eklendi";

            // ODEV 57 - AddRangeAsync & SaveChangesAsync
            await _context.Customers.AddRangeAsync(
                new Customer { CustomeName = "Müşteri 1", CustomeSurname = "Yılmaz", CustomeCity = "İstanbul" },
                new Customer { CustomeName = "Müşteri 2", CustomeSurname = "Kaya", CustomeCity = "Ankara" },
                new Customer { CustomeName = "Müşteri 3", CustomeSurname = "Demir", CustomeCity = "İzmir" }
            );
            await _context.SaveChangesAsync();
            ViewBag.addRangeAsyncResult = "3 müşteri eklendi";

            // ODEV 58 - AnyAsync
            ViewBag.anyAsyncResult = await _context.Products.AnyAsync(x => x.ProductStock == 0);

            // ODEV 59 - AllAsync
            ViewBag.allAsyncResult = await _context.Orders.AllAsync(x => x.IsActive);

            // ODEV 60 - Attach
            var detachedProduct = new Product { Id = 999 };
            var attachState = _context.Products.Attach(detachedProduct);
            ViewBag.attachState = attachState.State.ToString();

            // ODEV 61 - AttachRange
            _context.Customers.AttachRange(new Customer { Id = 998 }, new Customer { Id = 999 });
            ViewBag.attachRangeState = "2x Değişmeyen";

            // ODEV 62 - Entry
            var entryProduct = _context.Products.FirstOrDefault();
            if (entryProduct != null)
            {
                ViewBag.entryState = _context.Entry(entryProduct).State.ToString();
            }

            return View();
        }
    }
}
