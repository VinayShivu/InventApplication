using InventApplication.Domain.DTOs;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;
        private readonly ILogger _logger;
        public ItemsController(IItemsService itemsService, ILogger<ItemsController> logger)
        {
            _itemsService = itemsService;
            _logger = logger;
        }

        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="itemsRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("item")]
        public async Task<IActionResult> AddItem(ItemsDto itemsRequestDto)
        {
            _logger.LogInformation("Adding Item: {itemname}", itemsRequestDto.Name);
            var itemsAdded = await _itemsService.AddItems(itemsRequestDto);
            if (itemsAdded != null)
            {
                _logger.LogInformation("{success} : Item :{itemname}", Messages.ItemsRegisterSuccess, itemsRequestDto.Name);
                return Ok(new { message = Messages.ItemsRegisterSuccess, itemName = itemsAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Item :{itemname}", Messages.ItemsRegisterError, itemsRequestDto.Name);
                return BadRequest(new { message = Messages.ItemsRegisterError, currentDate = DateTime.Now });
            }
        }

    }
}
