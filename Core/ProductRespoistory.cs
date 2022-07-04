using System.Net.Http.Headers;
using AndelaTest.Data;
using AndelaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AndelaTest.Core
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task CreateProduct (Product Product)
        {
            if(Product == null)
                 throw new ArgumentNullException(nameof(Product));

            Product.DateCreated = DateTime.Now;
           await _context.Products.AddAsync(Product);
        }

        public async Task<Product?> GetProductById(int id)
        {
            if(id == 0 )
                throw new ArgumentNullException(nameof(id));

            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}