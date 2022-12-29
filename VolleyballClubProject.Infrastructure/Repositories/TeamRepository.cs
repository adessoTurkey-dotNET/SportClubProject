using Microsoft.EntityFrameworkCore;
using System.Data;
using VolleyballClub.Application.Interfaces;
using VolleyballClubProject.Core.Entities;
using VolleyballClubProject.Infrastructure.Context;

namespace VolleyballClubProject.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Team entity)
        {
            await _context.Teams.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task AddMember(int teamId, int personId)
        {
            var team = _context.Teams.ToList().Single(t => t.Id == teamId);
            var person = _context.People.ToList().Single(t => t.Id == personId);
            if (team != null && person != null)
                person.TeamId= teamId;
            _context.SaveChanges();
        }

        public async Task<Team> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);
            return team;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams;
        }

        public async Task<Team> GetTeamWithMembers(int teamId)
        {
            var team = await _context.Teams.Include(p => p.Members).Where(p => p.Id == teamId).SingleOrDefaultAsync();
            return team;
        }

        public void Remove(int id)
        {
            var person = _context.Teams.Where(x => x.Id == id).SingleOrDefault();
            _context.Teams.Remove(person);
            _context.SaveChanges();
        }

        public void Update(Team entity)
        {
            _context.Teams.Update(entity);
            _context.SaveChanges();
        }
    }
}
