using InventApplication.Domain.DTOs.Customer;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customerRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("customer")]
        public async Task<IActionResult> AddCustomer(CustomerDto customerRequestDto)
        {
            _logger.LogInformation("Adding Customer: {companyname}", customerRequestDto.CompanyName);
            var customerAdded = await _customerService.AddCustomer(customerRequestDto);
            if (customerAdded != null)
            {
                _logger.LogInformation("{success} : Customer :{companyname}", Messages.CustomerRegisterSuccess, customerRequestDto.CompanyName);
                return Ok(new { message = Messages.CustomerRegisterSuccess, customername = customerAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : customer :{companyname}", Messages.CustomerRegisterError, customerRequestDto.CompanyName);
                return BadRequest(new { message = Messages.CustomerRegisterError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get all Customer
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "AdminOrUser")]
        [HttpGet]
        [Route("customer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            _logger.LogInformation("Get All Customer");
            var customer = await _customerService.GetAllCustomerAsync();
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "AdminOrUser")]
        [HttpGet]
        [Route("customer/{customerid}")]
        public async Task<IActionResult> GetCustomerById(int customerid)
        {
            _logger.LogInformation("Get Customer by Id : {id}", customerid);
            var customer = await _customerService.GetCustomerByIdAsync(customerid);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }


        /// <summary>
        /// Get Customer by Name
        /// </summary>
        /// <param name="companyname"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "AdminOrUser")]
        [HttpGet]
        [Route("customercompanyname/{companyname}")]
        public async Task<IActionResult> GetCustomerByName(string companyname)
        {
            _logger.LogInformation("Get Customer by Company Name : {companyname}", companyname);
            var customer = await _customerService.GetCustomerByNameAsync(companyname);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }


        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("customer/{customerid}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto, int customerid)
        {
            _logger.LogInformation("Updating Customer : Customer Name: {companyname}", customerDto.CompanyName);
            var updatedCustomer = await _customerService.UpdateCustomer(customerDto, customerid);
            if (updatedCustomer)
            {
                _logger.LogInformation("{success} : Customer Name: {companyname}", Messages.CustomerUpdateSuccess, customerDto.CompanyName);
                return Ok(new { message = Messages.CustomerUpdateSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Customer Name: {companyname}", Messages.CustomerUpdateError, customerDto.CompanyName);
                return BadRequest(new { message = Messages.CustomerUpdateError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("customer/{customerid}")]
        public async Task<IActionResult> DeleteCustomer(int customerid)
        {
            _logger.LogInformation("Deleting Customer : Customer Id: {customerid}", customerid);
            var deletedCustomer = await _customerService.DeleteCustomer(customerid);
            if (deletedCustomer)
            {
                _logger.LogInformation("{success} : Customer Id: {customerid}", Messages.CustomerDeleteSuccess, customerid);
                return Ok(new { message = Messages.CustomerDeleteSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Customer Id: {customerid}", Messages.CustomerDeleteError, customerid);
                return BadRequest(new { message = Messages.CustomerDeleteError, currentDate = DateTime.Now });
            }
        }
    }
}
