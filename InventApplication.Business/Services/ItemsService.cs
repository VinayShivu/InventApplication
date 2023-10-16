using InventApplication.Domain.DTOs.Items;
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
                throw new ConflictException(Messages.ItemExists);
            }
        }

        public async Task<bool> InactiveItem(int itemid)
        {
            var result = await _itemRepository.GetItemByIdAsync(itemid);
            if (result == null)
            {
                throw new NotFoundException(Messages.InvalidItemId);
            }
            return await _itemRepository.InactiveItem(itemid);
        }

        public async Task<bool> ActiveItem(int itemid)
        {
            var result = await _itemRepository.GetItemByIdAsync(itemid);
            if (result == null)
            {
                throw new NotFoundException(Messages.InvalidItemId);
            }
            return await _itemRepository.ActiveItem(itemid);
        }

        public async Task<List<Items>> GetAllItemsAsync()
        {
            var result = await _itemRepository.GetAllItemAsync();
            if (result == null)
            {
                throw new CustomException(Messages.NoData);
            }
            return result;
        }

        public async Task<Items> GetItemByIdAsync(int itemid)
        {
            var result = await _itemRepository.GetItemByIdAsync(itemid);
            if (result == null)
            {
                throw new CustomException(Messages.NoData);
            }
            return result;
        }

        public async Task<Items> GetItemByNameAsync(string itemname)
        {
            var item = await _itemRepository.GetItemByNameAsync(itemname);
            if (item == null)
            {
                throw new NotFoundException(Messages.InvalidItemName);
            }
            return item;
        }

        public async Task<bool> UpdateItem(ItemsDto itemsRequestUpdateDto, int itemid)
        {
            var item = await _itemRepository.GetItemByIdAsync(itemid);
            if (item == null)
            {
                throw new NotFoundException(Messages.InvalidItemId);
            }
            item.Name = itemsRequestUpdateDto.Name;
            item.Description = itemsRequestUpdateDto.Description;
            item.Unit = itemsRequestUpdateDto.Unit;
            item.HSN = itemsRequestUpdateDto.HSN;
            item.Brand = itemsRequestUpdateDto.Brand;
            item.PartCode = itemsRequestUpdateDto.PartCode;
            item.GST = itemsRequestUpdateDto.GST;
            item.IGST = itemsRequestUpdateDto.IGST;
            item.SellingPrice = itemsRequestUpdateDto.SellingPrice;
            var retval = await _itemRepository.UpdateItem(item, itemid);
            return retval;
        }
    }
}
