using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IBuyerService
    {
        public Task<string> AddBuyer(BuyerDto buyer);
        public Task<Buyer> GetBuyerByIdAsync(int buyerid);
        public Task<IEnumerable<Buyer>> GetAllBuyerAsync();
        public Task<bool> UpdateBuyer(BuyerDto buyerRequestUpdateDto, int buyerid);
        public Task<bool> DeleteBuyer(int buyerid);
    }
}
