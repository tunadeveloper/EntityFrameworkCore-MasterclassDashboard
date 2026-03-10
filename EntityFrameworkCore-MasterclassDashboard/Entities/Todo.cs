using EntityFrameworkCore_MasterclassDashboard.Entities.Common;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Category { get; set; }
    }
}
