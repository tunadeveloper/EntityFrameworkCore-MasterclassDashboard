using EntityFrameworkCore_MasterclassDashboard.Entities.Common;

namespace EntityFrameworkCore_MasterclassDashboard.Entities
{
    public class Activity:BaseEntity
    {
        public string ActivityTitle { get; set; }
        public string ActivitySubTitle { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityType { get; set; }
    }
}
