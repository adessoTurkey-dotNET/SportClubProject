using Microsoft.EntityFrameworkCore;
using System.Data;
using VolleyballClubProject.Application.Interfaces;
using VolleyballClubProject.Core.Entities;
using VolleyballClubProject.Infrastructure.Context;

namespace VolleyballClubProject.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _context;

        public ContractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Contract entity)
        {
            await _context.Contracts.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<Contract> Get(int id)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(p => p.Id == id);
            return contract;
        }

        public async Task<IEnumerable<Contract>> GetAll()
        {
            var contracts = await _context.Contracts.ToListAsync();
            return contracts;
        }

        public void Remove(int id)
        {
            var contract = _context.Contracts.Where(p => p.Id == id).FirstOrDefault();
            _context.Contracts.Remove(contract);
            _context.SaveChanges();
        }

        public void Update(Contract entity)
        {
            _context.Contracts.Update(entity);
            _context.SaveChanges();
        }
    }
}
