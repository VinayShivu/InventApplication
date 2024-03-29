﻿using InventApplication.Domain.DTOs.Items;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IItemsService
    {
        public Task<string> AddItem(ItemsDto item);
        public Task<Items> GetItemByIdAsync(int itemid);
        public Task<Items> GetItemByNameAsync(string itemname);
        public Task<List<Items>> GetAllItemsAsync();
        public Task<bool> UpdateItem(ItemsDto itemsRequestUpdateDto, int itemid);
        public Task<bool> InactiveItem(int itemid);
        public Task<bool> ActiveItem(int itemid);
    }
}
