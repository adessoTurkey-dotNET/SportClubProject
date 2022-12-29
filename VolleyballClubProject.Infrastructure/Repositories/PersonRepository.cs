using Microsoft.EntityFrameworkCore;
using System.Data;
using VolleyballClubProject.Application.Interfaces;
using VolleyballClubProject.Core.Entities;
using VolleyballClubProject.Infrastructure.Context;

namespace VolleyballClubProject.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Person entity)
        {
            await _context.People.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task AddProduct(int personId, int productId)
        {
            var person = _context.People.ToList().Single(t => t.Id == personId);
            var product = _context.Products.ToList().Single(t => t.Id == productId);
            if (product != null && person != null)
            {
                product.PersonId = personId;
            }
            _context.SaveChanges();
        }

        public async Task<Person> Get(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == id);
            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var people = await _context.People.ToListAsync();
            return people;
        }

        public async Task<Person> GetPersonWithProducts(int personId)
        {
            var person = await _context.People.Include(p => p.Products).Where(p => p.Id == personId).SingleOrDefaultAsync();
            return person;
        }

        public void Remove(int id)
        {
            var person = _context.People.Where(p => p.Id == id).FirstOrDefault();
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }

        public void Update(Person entity)
        {
            _context.People.Update(entity);
            _context.SaveChanges();
        }
    }
}
