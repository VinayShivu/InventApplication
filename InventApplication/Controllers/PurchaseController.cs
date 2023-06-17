using InventApplication.Domain.DTOs;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly ILogger _logger;
        public PurchaseController(IPurchaseService purchaseService, ILogger<PurchaseController> logger)
        {
            _purchaseService = purchaseService;
            _logger = logger;
        }

        /// <summary>
        /// Add Purchase
        /// </summary>
        /// <param name="purchaseRequestDto"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> AddPurchase(PurchaseDto purchaseRequestDto)
        {
            _logger.LogInformation("Adding Purchase of Vendor: {vendorname}", purchaseRequestDto.VendorName);
            var purchaseAdded = await _purchaseService.AddPurchase(purchaseRequestDto);
            if (purchaseAdded != null)
            {
                _logger.LogInformation("{success} : Purchase of Vendor :{vendorname}", Messages.PurchaseRegisterSuccess, purchaseRequestDto.VendorName);
                return Ok(new { message = Messages.PurchaseRegisterSuccess, vendorname = purchaseAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Purchase of Vendor:{vendorname}", Messages.PurchaseRegisterError, purchaseRequestDto.VendorName);
                return BadRequest(new { message = Messages.PurchaseRegisterError, currentDate = DateTime.Now });
            }
        }

    }
}
