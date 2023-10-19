using InventApplication.Domain.DTOs.Dropdowns;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IDropdownService
    {
        Task<DropDownValuesDto> GetDropDownListAsync();
    }
}
