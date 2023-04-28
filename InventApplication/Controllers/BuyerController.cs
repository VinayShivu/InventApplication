using InventApplication.Domain.DTOs;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InventApplication.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        private readonly ILogger _logger;
        public BuyerController(IBuyerService buyerService, ILogger<BuyerController> logger)
        {
            _buyerService = buyerService;
            _logger = logger;
        }

        /// <summary>
        /// Add Buyer
        /// </summary>
        /// <param name="buyerRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("buyer")]
        public async Task<IActionResult> AddBuyer(BuyerDto buyerRequestDto)
        {
            _logger.LogInformation("Adding Buyer: {buyername}", buyerRequestDto.BuyerName);
            var buyerAdded = await _buyerService.AddBuyer(buyerRequestDto);
            if (buyerAdded != null)
            {
                _logger.LogInformation("{success} : Buyer :{buyername}", Messages.BuyerRegisterSuccess, buyerRequestDto.BuyerName);
                return Ok(new { message = Messages.BuyerRegisterSuccess, buyerename = buyerAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : buyer :{buyername}", Messages.BuyerRegisterError, buyerRequestDto.BuyerName);
                return BadRequest(new { message = Messages.BuyerRegisterError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get all Buyer
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("buyer")]
        public async Task<IActionResult> GetAllBuyer()
        {
            _logger.LogInformation("Get All Buyer");
            var buyer = await _buyerService.GetAllBuyerAsync();
            if (buyer != null)
            {
                return Ok(buyer);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get Buyer by Id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("buyer/{buyerid}")]
        public async Task<IActionResult> GetBuyerById(int buyerid)
        {
            _logger.LogInformation("Get Buyer by Id : {id}", buyerid);
            var buyer = await _buyerService.GetBuyerByIdAsync(buyerid);
            if (buyer != null)
            {
                return Ok(buyer);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Update Buyer
        /// </summary>
        /// <param name="buyerDto">Buyer update request</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("buyer/{buyerid}")]
        public async Task<IActionResult> UpdateBuyer([FromBody] BuyerDto buyerDto, int buyerid)
        {
            _logger.LogInformation("Updating Buyer : Buyer Name: {buyername}", buyerDto.BuyerName);
            var updatedBuyer = await _buyerService.UpdateBuyer(buyerDto, buyerid);
            if (updatedBuyer)
            {
                _logger.LogInformation("{success} : Buyer Name: {buyername}", Messages.BuyerUpdateSuccess, buyerDto.BuyerName);
                return Ok(new { message = Messages.BuyerUpdateSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Buyer Name: {buyername}", Messages.BuyerUpdateError, buyerDto.BuyerName);
                return BadRequest(new { message = Messages.BuyerUpdateError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Delete Buyer
        /// </summary>
        /// <param name="buyerid">Buyer id to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("buyer/{buyerid}")]
        public async Task<IActionResult> DeleteBuyer(int buyerid)
        {
            _logger.LogInformation("Deleting Buyer : Buyer Id: {buyerid}", buyerid);
            var deletedBuyer = await _buyerService.DeleteBuyer(buyerid);
            if (deletedBuyer)
            {
                _logger.LogInformation("{success} : Buyer Id: {buyerid}", Messages.BuyerDeleteSuccess, buyerid);
                return Ok(new { message = Messages.BuyerDeleteSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Buyer Id: {buyerid}", Messages.BuyerDeleteError, buyerid);
                return BadRequest(new { message = Messages.BuyerDeleteError, currentDate = DateTime.Now });
            }
        }
    }
}
