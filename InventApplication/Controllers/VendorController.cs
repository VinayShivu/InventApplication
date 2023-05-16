using InventApplication.Domain.DTOs;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly ILogger _logger;
        public VendorController(IVendorService vendorService, ILogger<VendorController> logger)
        {
            _vendorService = vendorService;
            _logger = logger;
        }

        /// <summary>
        /// Add vendor
        /// </summary>
        /// <param name="vendorRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("vendor")]
        public async Task<IActionResult> Addvendor(VendorDto vendorRequestDto)
        {
            _logger.LogInformation("Adding vendor: {vendorname}", vendorRequestDto.CompanyName);
            var vendorAdded = await _vendorService.AddVendor(vendorRequestDto);
            if (vendorAdded != null)
            {
                _logger.LogInformation("{success} : Vendor :{vendorname}", Messages.VendorRegisterSuccess, vendorRequestDto.CompanyName);
                return Ok(new { message = Messages.VendorRegisterSuccess, vendorename = vendorAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Vendor :{vendorname}", Messages.VendorRegisterError, vendorRequestDto.CompanyName);
                return BadRequest(new { message = Messages.VendorRegisterError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get all Vendor
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("vendor")]
        public async Task<IActionResult> GetAllVendor()
        {
            _logger.LogInformation("Get All Vendor");
            var vendor = await _vendorService.GetAllVendorAsync();
            if (vendor != null)
            {
                return Ok(vendor);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get Vendor by Id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("vendor/{vendorid}")]
        public async Task<IActionResult> GetVendorById(int vendorid)
        {
            _logger.LogInformation("Get Vendor by Id : {id}", vendorid);
            var vendor = await _vendorService.GetVendorByIdAsync(vendorid);
            if (vendor != null)
            {
                return Ok(vendor);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get Vendor by name
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("vendorcompanyname/{companyname}")]
        public async Task<IActionResult> GetVendorByName(string companyname)
        {
            _logger.LogInformation("Get Vendor by Name : {companyname}", companyname);
            var vendor = await _vendorService.GetVendorByNameAsync(companyname);
            if (vendor != null)
            {
                return Ok(vendor);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }


        /// <summary>
        /// Update Vendor
        /// </summary>
        /// <param name="vendorDto">Vendor update request</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("vendor/{vendorid}")]
        public async Task<IActionResult> UpdateVendor([FromBody] VendorDto vendorDto, int vendorid)
        {
            _logger.LogInformation("Updating Vendor : Vendor Name: {vendorname}", vendorDto.CompanyName);
            var updatedVendor = await _vendorService.UpdateVendor(vendorDto, vendorid);
            if (updatedVendor)
            {
                _logger.LogInformation("{success} : Vendor Name: {vendorname}", Messages.VendorUpdateSuccess, vendorDto.CompanyName);
                return Ok(new { message = Messages.VendorUpdateSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Vendor Name: {vendorname}", Messages.VendorUpdateError, vendorDto.CompanyName);
                return BadRequest(new { message = Messages.VendorUpdateError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Delete Vendor
        /// </summary>
        /// <param name="vendorid">Vendor id to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("vendor/{vendorid}")]
        public async Task<IActionResult> DeleteVendor(int vendorid)
        {
            _logger.LogInformation("Deleting Vendor : Vendor Id: {vendorid}", vendorid);
            var deletedvendor = await _vendorService.DeleteVendor(vendorid);
            if (deletedvendor)
            {
                _logger.LogInformation("{success} : Vendor Id: {vendorid}", Messages.VendorDeleteSuccess, vendorid);
                return Ok(new { message = Messages.VendorDeleteSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Vendor Id: {vendorid}", Messages.VendorDeleteError, vendorid);
                return BadRequest(new { message = Messages.VendorDeleteError, currentDate = DateTime.Now });
            }
        }
    }
}
