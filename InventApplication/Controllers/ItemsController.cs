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
            var itemsAdded = await _itemsService.AddItem(itemsRequestDto);
            if (itemsAdded != null)
            {
                _logger.LogInformation("{success} : Item :{itemname}", Messages.ItemRegisterSuccess, itemsRequestDto.Name);
                return Ok(new { message = Messages.ItemRegisterSuccess, itemName = itemsAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Item :{itemname}", Messages.ItemRegisterError, itemsRequestDto.Name);
                return BadRequest(new { message = Messages.ItemRegisterError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("allitems")]
        public async Task<IActionResult> GetAllItems()
        {
            _logger.LogInformation("Get All Items");
            var items = await _itemsService.GetAllItemsAsync();
            if (items != null)
            {
                return Ok(items);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get Item by Name
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("itembyname/{itemname}")]
        public async Task<IActionResult> GetItemByName(string itemname)
        {
            _logger.LogInformation("Get Item by Item Name : {itemname}", itemname);
            var item = await _itemsService.GetItemByNameAsync(itemname);
            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }


        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("itembyid/{itemid}")]
        public async Task<IActionResult> GetItemById(int itemid)
        {
            _logger.LogInformation("Get Item by Item Name : {itemid}", itemid);
            var item = await _itemsService.GetItemByIdAsync(itemid);
            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

    }
}
