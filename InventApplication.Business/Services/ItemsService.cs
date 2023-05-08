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
        public async Task<string> AddItems(ItemsDto items)
        {
            //var getitems = _itemRepository.GetItemsByNameAsync(items.Name).Result;
            var getitems = "null";
            if (getitems == "null")
            {
                var newItems = new Items
                {
                    Name = items.Name,
                    Description = items.Description,
                    Unit = items.Unit,
                    HSN = items.HSN,
                    Brand = items.Brand,
                    PartCode = items.PartCode,
                    GST = items.GST,
                    IGST = items.IGST,
                    SellingPrice = items.SellingPrice,

                };
                var retVal = await _itemRepository.AddItems(newItems);

                return retVal ? newItems.Name : null;
            }
            else
            {
                throw new RepositoryException(Messages.ItemsExists);
            }
        }

        public Task<bool> DeleteItems(int itemsid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Items>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Items> GetItemsByIdAsync(int itemsid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItems(ItemsDto itemsRequestUpdateDto, int itemsid)
        {
            throw new NotImplementedException();
        }
    }
}
