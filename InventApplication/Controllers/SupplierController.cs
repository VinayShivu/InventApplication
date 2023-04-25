using InventApplication.Domain.DTOs;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Authorize]
    [Route("api/")]
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
        [Route("supplier")]
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

        /// <summary>
        /// Get all Supplier
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("supplier")]
        public async Task<IActionResult> GetAllSupplier()
        {
            _logger.LogInformation("Get All Supplier");
            var supplier = await _supplierService.GetAllSupplierAsync();
            if (supplier != null)
            {
                return Ok(supplier);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get Supplier by Id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("supplier/{supplierid}")]
        public async Task<IActionResult> GetSupplierById(int supplierid)
        {
            _logger.LogInformation("Get Supplier by Id : {id}", supplierid);
            var supplier = await _supplierService.GetSupplierByIdAsync(supplierid);
            if (supplier != null)
            {
                return Ok(supplier);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Update Supplier
        /// </summary>
        /// <param name="supplierDto">Supplier update request</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("supplier/{supplierid}")]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierDto supplierDto, int supplierid)
        {
            _logger.LogInformation("Updating Supplier : Supplier Name: {suppliername}", supplierDto.SupplierName);
            var updatedSupplier = await _supplierService.UpdateSupplier(supplierDto, supplierid);
            if (updatedSupplier)
            {
                _logger.LogInformation("{success} : Supplier Name: {suppliername}", Messages.SupplierUpdateSuccess, supplierDto.SupplierName);
                return Ok(new { message = Messages.SupplierUpdateSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Supplier Name: {suppliername}", Messages.SupplierUpdateError, supplierDto.SupplierName);
                return BadRequest(new { message = Messages.SupplierUpdateError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Delete Supplier
        /// </summary>
        /// <param name="supplierid">Supplier id to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("supplier/{supplierid}")]
        public async Task<IActionResult> DeleteSupplier(int supplierid)
        {
            _logger.LogInformation("Deleting Supplier : Supplier Id: {supplierid}", supplierid);
            var deletedSupplier = await _supplierService.DeleteSupplier(supplierid);
            if (deletedSupplier)
            {
                _logger.LogInformation("{success} : Supplier Id: {supplierid}", Messages.SupplierDeleteSuccess, supplierid);
                return Ok(new { message = Messages.SupplierDeleteSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Supplier Id: {supplierid}", Messages.SupplierDeleteError, supplierid);
                return BadRequest(new { message = Messages.SupplierDeleteError, currentDate = DateTime.Now });
            }
        }
    }
}
