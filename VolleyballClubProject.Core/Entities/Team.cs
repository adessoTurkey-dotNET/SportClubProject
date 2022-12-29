using VolleyballClubProject.Core.Common;

namespace VolleyballClubProject.Core.Entities
{
    public class Team : BaseEntity
    {
        public ICollection<Person> Members { get; set; }
    }
}
