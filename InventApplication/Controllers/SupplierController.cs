using InventApplication.Domain.DTOs;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Authorize]
    [Route("")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ILogger _logger;
        public SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        /// <summary>
        /// Add Supplier
        /// </summary>
        /// <param name="supplierRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("api/supplier")]
        public async Task<IActionResult> AddSupplier(SupplierDto supplierRequestDto)
        {
            _logger.LogInformation("Adding Supplier: {suppliername}", supplierRequestDto.SupplierName);
            var supplierAdded = await _supplierService.AddSupplier(supplierRequestDto);
            if (supplierAdded != null)
            {
                _logger.LogInformation("{success} : Supplier :{suppliername}", Messages.SupplierRegisterSuccess, supplierRequestDto.SupplierName);
                return Ok(new { message = Messages.SupplierRegisterSuccess, supplierename = supplierAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Supplier :{suppliername}", Messages.SupplierRegisterError, supplierRequestDto.SupplierName);
                return BadRequest(new { message = Messages.SupplierRegisterError, currentDate = DateTime.Now });
            }
        }

    }
}
