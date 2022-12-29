using VolleyballClubProject.Core.Common;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClub.Application.Interfaces
{
    public interface ITeamRepository : IBaseInterface<Team>
    {
        Task AddMember(int teamId, int personId);
        Task<Team> GetTeamWithMembers(int teamId);
    }
}
