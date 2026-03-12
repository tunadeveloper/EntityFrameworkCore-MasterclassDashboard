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

        public IActionResult Index()
        {
            // ODEV 1 - ToList
            // ViewBag.productList = ...
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
            // ViewBag.findCustomer = ...   -> musteri adi soyadi
            var findCustomer = _context.Customers.Find(10);
            ViewBag.findCustomer = $"{findCustomer.CustomeName} {findCustomer.CustomeSurname}";

            // ODEV 4 - Remove & SaveChanges
            // ViewBag.removedOrder = ...   -> "Siparis #X silindi"

            // ODEV 5 - Update & SaveChanges
            // ViewBag.updatedProduct = ...   -> "Fiyat X -> Y"

            // ODEV 6 - Count
            // ViewBag.activeCount = ...   -> aktif urun sayisi
            ViewBag.activeCount = _context.Products.Where(x => x.IsActive).Count();

            // ODEV 7 - Min
            // ViewBag.lowPriceProduct = ...   -> en dusuk fiyat
            ViewBag.lowPriceProduct = _context.Products.Select(x => x.ProductPrice).Min();

            // ODEV 8 - Max
            // ViewBag.highBalanceCustomer = ...   -> en yuksek bakiye
            ViewBag.highBalanceCustomer = _context.Customers.Select(x => x.CustomeBalance).Max();

            // ODEV 9 - Sum
            // ViewBag.totalCustomerBalance = ...   -> toplam bakiye
            ViewBag.totalCustomerBalance = _context.Customers.Sum(x => x.CustomeBalance);

            // ODEV 10 - Average
            // ViewBag.avgProductStock = ...   -> ortalama stok
            ViewBag.avgProductStock = _context.Products.Average(x => x.ProductStock);

            // ODEV 11 - LongCount
            // ViewBag.totalOrderLong = ...   -> long tipinde siparis sayisi
            ViewBag.totalOrderLong = _context.Orders.LongCount();

            // ODEV 12 - CountBy
            // ViewBag.productActiveGroups = ...   -> KeyValuePair<bool,int> listesi
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
            ViewBag.containsHeadphone = _context.Products.Where(x => x.ProductName.Contains("USB"));

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
            ViewBag.defaultIfEmptyResult = _context.Products.Where(x=>x.ProductPrice > 99999).Select(x=>x.ProductName).DefaultIfEmpty("Sonuç Yok").FirstOrDefault();

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
            ViewBag.skipLastProducts = _context.Orders.OrderBy(x => x.Id).SkipLast(5).Select(x=>x.Id).Last();

            // ODEV 34 - Reverse
            ViewBag.reversedProducts = _context.Products.OrderBy(x => x.Id).Reverse().Select(x=>x.ProductName).First();

            // ODEV 35 - Chunk
            var allOrder = _context.Orders.ToList();
            ViewBag.chunkedOrders = allOrder.Chunk(10).FirstOrDefault().Count();

            // ODEV 36 - Index
            var products = _context.Products.AsNoTracking().ToList();
            return View();
        }


        // ODEV 36 - Index
        // Tum urunleri index numarasiyla birlikte listele (0'dan baslayan sira).
        // ViewBag.indexedProducts = ...   -> "Index: 0 -> 86" gibi ozet


        // ============================================================
        //  GRUP 5 - Set / Kume Islemleri
        // ============================================================

        // ODEV 37 - Distinct
        // Musterilerin kayitli olduklari benzersiz sehirleri listele.
        // ViewBag.distinctCities = ...   -> sehir sayisi

        // ODEV 38 - Union
        // Fiyati 100 TL altindaki ve 900 TL ustundeki urunleri birlestir.
        // ViewBag.unionProducts = ...   -> Count

        // ODEV 39 - UnionBy
        // Aktif urunler ile stogu 0'dan buyuk urunleri Id'ye gore tekrarsiz birlestir.
        // ViewBag.unionByProducts = ...   -> Count

        // ODEV 40 - Concat
        // Istanbul ve Ankara'daki musterileri tek listede birlestir (tekrarlar dahil).
        // ViewBag.concatCustomers = ...   -> Count

        // ODEV 41 - Except
        // Tum urun adlarindan yalnizca stokta olanlarin adlarini cikar.
        // ViewBag.exceptProducts = ...   -> Count

        // ODEV 42 - ExceptBy
        // Tum siparislerden, toplam fiyati 1000 TL uzerinde olanlari Id bazli cikar.
        // ViewBag.exceptByOrders = ...   -> Count

        // ODEV 43 - Intersect
        // Hem aktif hem de stogu 0'dan buyuk olan urunlerin kesisimini bul.
        // ViewBag.intersectProducts = ...   -> Count

        // ODEV 44 - GroupBy
        // Siparisleri musteri Id'sine gore grupla; her musterinin siparis sayisini listele.
        // ViewBag.groupedOrders = ...   -> grup sayisi

        // ODEV 45 - GroupJoin
        // Tum kategorileri, her kategorideki urun listesiyle birlestir.
        // ViewBag.groupJoinResult = ...   -> kategori sayisi

        // ODEV 46 - Join
        // Siparisleri urunlerle birlestir; siparis Id, urun adi, fiyat goster.
        // ViewBag.joinResult = ...   -> eslesen kayit sayisi


        // ============================================================
        //  GRUP 6 - Zincir / Akis Islemleri
        // ============================================================

        // ODEV 47 - Append
        // Urun listesinin sonuna gecici bir urun ekle (veritabanina kaydedilmez).
        // ViewBag.appendedList = ...   -> Count (orijinal + 1)

        // ODEV 48 - Prepend
        // Urun listesinin basina gecici bir urun ekle.
        // ViewBag.prependedList = ...   -> Count (orijinal + 1)

        // ODEV 49 - Aggregate
        // Tum urun adlarini virgülle ayirarak tek bir string'e donustur.
        // ViewBag.aggregatedNames = ...   -> "Laptop, Telefon, ..."

        // ODEV 50 - Cast<T>
        // Urun listesini object tipine donustur; ardindan Product tipine cast et.
        // ViewBag.castedProducts = ...   -> Count

        // ODEV 51 - OfType<T>
        // Karisik tipteki object listesinden yalnizca Product olanlari filtrele.
        // ViewBag.ofTypeProducts = ...   -> Count

        // ODEV 52 - AsParallel
        // Urun listesini paralel isleyerek fiyati 500 TL uzerinde olanlari filtrele.
        // ViewBag.parallelProducts = ...   -> Count


        // ============================================================
        //  GRUP 7 - Async & Range Islemleri
        // ============================================================

        // ODEV 53 - ToListAsync
        // Tum musterileri asenkron olarak listele.
        // ViewBag.asyncCustomers = ...   -> Count

        // ODEV 54 - AddAsync & SaveChangesAsync
        // Yeni bir kategori asenkron olarak ekle ve degisiklikleri asenkron kaydet.
        // ViewBag.asyncAddedCategory = ...   -> eklenen kategori adi

        // ODEV 55 - FindAsync
        // Id ile ilgili siparisi asenkron olarak bul.
        // ViewBag.asyncFoundOrder = ...   -> siparis ozeti

        // ODEV 56 - AddRange
        // 3 adet yeni urunu tek cagriyla toplu olarak veritabanina ekle.
        // ViewBag.addRangeResult = ...   -> "3 urun eklendi"

        // ODEV 57 - AddRangeAsync & SaveChangesAsync
        // 3 adet yeni musteriyi asenkron ve toplu olarak ekle, kaydet.
        // ViewBag.addRangeAsyncResult = ...   -> "3 musteri eklendi"

        // ODEV 58 - AnyAsync
        // Asenkron olarak: stok miktari 0 olan urun var mi?
        // ViewBag.anyAsyncResult = ...   -> bool (true/false)

        // ODEV 59 - AllAsync
        // Asenkron olarak: tum siparislerin IsActive alani true mu?
        // ViewBag.allAsyncResult = ...   -> bool (true/false)


        // ============================================================
        //  GRUP 8 - Izleme & Varlik Yonetimi
        // ============================================================

        // ODEV 60 - Attach
        // Bagim disinda olusturulmus bir urun nesnesini context'e bagla ve takibe al.
        // ViewBag.attachState = ...   -> "Unchanged"

        // ODEV 61 - AttachRange
        // Birden fazla musteri nesnesini ayni anda context'e ekleyip takibe al.
        // ViewBag.attachRangeState = ...   -> "2x Unchanged"

        // ODEV 62 - Entry
        // Bir urunu bul, Entry ile durumunu (EntityState) oku ve konsola yazdir.
        // ViewBag.entryState = ...   -> "Modified" / "Unchanged" vb.
    }
}
