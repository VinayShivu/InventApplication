using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemRepository;
        public ItemsService(IItemsRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<string> AddItem(ItemsDto item)
        {
            var getitem = _itemRepository.GetItemByNameAsync(item.Name);
            if (getitem == null)
            {
                var newItem = new Items
                {
                    Name = item.Name,
                    Description = item.Description,
                    Unit = item.Unit,
                    HSN = item.HSN,
                    Brand = item.Brand,
                    PartCode = item.PartCode,
                    GST = item.GST,
                    IGST = item.IGST,
                    SellingPrice = item.SellingPrice,
                };
                var retVal = await _itemRepository.AddItem(newItem);

                return retVal ? newItem.Name : null;
            }
            else
            {
                throw new RepositoryException(Messages.ItemExists);
            }
        }

        public Task<bool> DeleteItem(int itemid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Items>> GetAllItemsAsync()
        {
            var result = await _itemRepository.GetAllItemAsync();
            if (result == null)
            {
                throw new RepositoryException(Messages.NoData);
            }
            return result;
        }

        public async Task<Items> GetItemByIdAsync(int itemid)
        {
            var result = await _itemRepository.GetItemByIdAsync(itemid);
            if (result == null)
            {
                throw new RepositoryException(Messages.NoData);
            }
            return result;
        }

        public async Task<Items> GetItemByNameAsync(string itemname)
        {
            var item = await _itemRepository.GetItemByNameAsync(itemname);
            if (item == null)
            {
                throw new RepositoryException(Messages.InvalidItemName);
            }
            return item;
        }

        public Task<bool> UpdateItem(ItemsDto itemsRequestUpdateDto, int itemid)
        {
            throw new NotImplementedException();
        }
    }
}
