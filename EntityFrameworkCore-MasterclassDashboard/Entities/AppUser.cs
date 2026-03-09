using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
