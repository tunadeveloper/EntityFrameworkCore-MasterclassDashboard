using EntityFrameworkCore_MasterclassDashboard.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_MasterclassDashboard.Context
{
    public class MasterclassContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public MasterclassContext(DbContextOptions<MasterclassContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
