using VolleyballClubProject.Core.Common;

namespace VolleyballClubProject.Core.Entities
{
    public class Person : BaseEntity
    {
        public string? Gender { get; set; }
        public ICollection<Product>? Products { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int? ContractId { get; set; }
        public Contract? Contract { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
