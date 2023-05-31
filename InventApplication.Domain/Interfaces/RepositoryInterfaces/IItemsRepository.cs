using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IItemsRepository
    {
        public Task<bool> AddItem(Items item);
        public Task<Items> GetItemByIdAsync(int itemid);
        public Task<List<Items>> GetAllItemAsync();
        public Task<bool> DeleteItem(int itemid);
        public Task<Items> GetItemByNameAsync(string itemname);
    }
}
