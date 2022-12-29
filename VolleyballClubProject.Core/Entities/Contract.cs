using VolleyballClubProject.Core.Common;

namespace VolleyballClubProject.Core.Entities
{
    public class Contract : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<Person> People { get; set; }

    }
}
