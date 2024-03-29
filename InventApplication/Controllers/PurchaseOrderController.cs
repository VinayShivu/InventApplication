﻿using InventApplication.Domain.DTOs.PurchaseOrder;
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

        /// <summary>
        /// Get the Purchase Order List.
        /// </summary>
        /// <param name="getPurchaseOrderRequest">Search Purchase Order request.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("purchaseorderlist")]
        public async Task<IActionResult> GetPurchaseOrderList(PurchaseOrderSearchRequestDto getPurchaseOrderRequest)
        {
            List<PurchaseOrderViewListDto> purchaseOrderList = await _purchaseorderService.GetPurchaseOrderist(getPurchaseOrderRequest);
            return Ok(purchaseOrderList);
        }

        /// <summary>
        /// Get the requested Purchase Order Details.
        /// </summary>
        /// <param name="id">Purchase Order Id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        [Route("purchaseorder/{id}")]
        public async Task<IActionResult> GetPurchaseOrder(int id)
        {
            PurchaseOrderDto purchaseOrderData = await _purchaseorderService.GetPurchaseOrder(id);
            return Ok(purchaseOrderData);
        }
    }
}
