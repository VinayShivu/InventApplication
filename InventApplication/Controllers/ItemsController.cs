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
        /// <param name="itemname"></param>
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
        /// <param name="itemid"></param>
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

        /// <summary>
        /// InActive a Item
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("inactiveitem/{itemid}")]
        public async Task<IActionResult> InActiveItem(int itemid)
        {
            _logger.LogInformation("InActive Item Id : {itemid}", itemid);
            var inactiveitem = await _itemsService.InactiveItem(itemid);
            if (inactiveitem)
            {
                _logger.LogInformation("{success} : Item Id :{itemid}", Messages.ItemInActivedSuccess, itemid);
                return Ok(new { message = Messages.ItemInActivedSuccess, itemid = itemid, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Item Id :{itemid}", Messages.ItemInActivedError, itemid);
                return BadRequest(new { message = Messages.ItemInActivedError, currentDate = DateTime.Now });
            }
        }


        /// <summary>
        /// Active a Item
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("activeitem/{itemid}")]
        public async Task<IActionResult> ActiveItem(int itemid)
        {
            _logger.LogInformation("Active Item Id : {itemid}", itemid);
            var activeitem = await _itemsService.ActiveItem(itemid);
            if (activeitem)
            {
                _logger.LogInformation("{success} : Item Id :{itemid}", Messages.ItemActivedSuccess, itemid);
                return Ok(new { message = Messages.ItemActivedSuccess, itemid = itemid, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Item Id :{itemid}", Messages.ItemActivedError, itemid);
                return BadRequest(new { message = Messages.ItemActivedError, currentDate = DateTime.Now });
            }
        }
    }
}
