using InventApplication.Domain.DTOs.Dropdowns;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class DropdownService : IDropdownService
    {
        private readonly IDropdownRepository _dropdownRepository;

        public DropdownService(IDropdownRepository dropdownRepository)
        {
            _dropdownRepository = dropdownRepository;
        }

        public async Task<DropDownValuesDto> GetDropDownListAsync()
        {
            List<DropDownValues> response = await _dropdownRepository.GetDropDownListAsync();
            if (!response.Any() && response.Count == 0)
            {
                throw new CustomException(Messages.NoData);
            }
            DropDownValuesDto rtnResponse = new()
            {
                VendorName = response.Where(x => x.Field.Equals("vendorname")).Select(p => new Common { Id = p.Id, Name = p.Name }).ToList(),

            };
            return rtnResponse;
        }
    }
}
