using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IBuyerRepository
    {
        public Task<bool> AddBuyer(Buyer buyer);
        public Task<Buyer> GetBuyerByIdAsync(int buyerid);
        public Task<IEnumerable<Buyer>> GetAllBuyerAsync();
        public Task<bool> UpdateBuyer(Buyer buyerUpdate, int buyerid);
        public Task<bool> DeleteBuyer(int buyerid);
        public Task<Buyer> GetBuyerByNameAsync(string buyername);
    }
}
