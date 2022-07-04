using AndelaTest.Core;
using AndelaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AndelaTest.Data
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly AppDbContext _context;

        public MerchantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Merchant>> GetAllMerchants()
        {
            return await _context.Merchants.ToListAsync();
        }

    }
}