using EntityFrameworkCore_MasterclassDashboard.Entities.Common;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class Order:BaseEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int SaleCount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
