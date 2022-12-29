using VolleyballClubProject.Core.Common;

namespace VolleyballClubProject.Core.Entities
{
    public class UserInfo : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
