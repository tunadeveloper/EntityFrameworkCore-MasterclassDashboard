using EntityFrameworkCore_MasterclassDashboard.Entities.Common;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
