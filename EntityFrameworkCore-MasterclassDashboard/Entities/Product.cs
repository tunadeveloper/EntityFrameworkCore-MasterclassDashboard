using EntityFrameworkCore_MasterclassDashboard.Entities.Common;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Order> Orders { get; set; }
    }
}
