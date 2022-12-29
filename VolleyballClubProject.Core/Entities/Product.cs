using VolleyballClubProject.Core.Common;

namespace VolleyballClubProject.Core.Entities
{
    public class Product : BaseEntity
    {
        public int Stock { get; set; }
        public double Price { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
