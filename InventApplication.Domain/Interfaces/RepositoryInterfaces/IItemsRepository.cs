using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IItemsRepository
    {
        public Task<bool> AddItems(Items items);
        public Task<Items> GetItemsByIdAsync(int itemsid);
        public Task<IEnumerable<Items>> GetAllItemsAsync();
        public Task<bool> DeleteItems(int itemsid);
        public Task<Items> GetItemsByNameAsync(string itemsname);
    }
}
