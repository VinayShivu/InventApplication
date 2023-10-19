using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseorderService;
        private readonly ILogger _logger;
        public PurchaseOrderController(IPurchaseOrderService purchaseorderService, ILogger<PurchaseOrderController> logger)
        {
            _purchaseorderService = purchaseorderService;
            _logger = logger;
        }

        /// <summary>
        /// Add Purchase Order
        /// </summary>
        /// <param name="addPurchaseOrderRequest"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("purchaseorder")]
        public async Task<IActionResult> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest)
        {
            var purchaseAdded = await _purchaseorderService.AddPurchaseOrder(addPurchaseOrderRequest);
            if (purchaseAdded)
            {
                return Ok(new { message = Messages.PurchaseOrderRegisterSuccess, currentDate = DateTime.Now });
            }
            else
            {
                return BadRequest(new { message = Messages.PurchaseOrderRegisterError, currentDate = DateTime.Now });
            }
        }

    }
}
