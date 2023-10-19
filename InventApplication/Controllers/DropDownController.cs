using InventApplication.Domain.DTOs.Dropdowns;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventApplication.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly IDropdownService _dropdownService;

        public DropDownController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }

        /// <summary>
        ///Get DropDown Values
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("dropdownlist")]
        public async Task<IActionResult> GetDropDownListAsync()
        {
            DropDownValuesDto response = await _dropdownService.GetDropDownListAsync();
            return Ok(response);
        }
    }
}
