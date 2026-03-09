using EntityFrameworkCore_MasterclassDashboard.Entities.Common;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class Customer:BaseEntity
    {
        public string CustomeName { get; set; }
        public string CustomeSurname { get; set; }
        public string? CustomerImageUrl { get; set; }
        public string CustomeCity { get; set; }
        public string? CustomeDistrict { get; set; }
        public decimal CustomeBalance { get; set; }

        public List<Order> Orders { get; set; }
    }
}
