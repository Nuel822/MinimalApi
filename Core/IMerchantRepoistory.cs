using AndelaTest.Models;

namespace AndelaTest.Core
{
    public interface IMerchantRepository
    {
       Task<IEnumerable<Merchant>> GetAllMerchants();
        
    }
}