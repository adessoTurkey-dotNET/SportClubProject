using Microsoft.EntityFrameworkCore;
using System.Data;
using VolleyballClubProject.Application.Interfaces;
using VolleyballClubProject.Core.Entities;
using VolleyballClubProject.Infrastructure.Context;

namespace VolleyballClubProject.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product entity)
        {
            await _context.Products.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<Product> Get(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public void Remove(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
