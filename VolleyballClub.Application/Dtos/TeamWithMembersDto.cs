namespace VolleyballClub.Application.Dtos
{
    public class TeamWithMembersDto : TeamDto
    {
        public List<PersonDto> Members { get; set; }
    }
}
