using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products
                .Include(x => x.Photos)
                .Include(x => x.Category)
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}