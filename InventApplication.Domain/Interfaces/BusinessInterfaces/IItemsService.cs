using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IItemsService
    {
        public Task<string> AddItems(ItemsDto items);
        public Task<Items> GetItemsByIdAsync(int itemsid);
        public Task<IEnumerable<Items>> GetAllItemsAsync();
        public Task<bool> UpdateItems(ItemsDto itemsRequestUpdateDto, int itemsid);
        public Task<bool> DeleteItems(int itemsid);
    }
}
