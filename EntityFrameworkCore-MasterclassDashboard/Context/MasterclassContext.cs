using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_MasterclassDashboard.Context
{
    public class MasterclassContext : DbContext
    {
        public MasterclassContext(DbContextOptions<MasterclassContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
