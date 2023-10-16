using InventApplication.Domain.DTOs.Vendor;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IVendorService
    {
        public Task<string> AddVendor(VendorRequestDto vendor);
        public Task<VendorResponseDto> GetVendorByIdAsync(int vendorid);
        public Task<IEnumerable<VendorResponseDto>> GetAllVendorAsync();
        public Task<bool> UpdateVendor(VendorRequestDto vendorRequestUpdateDto, int vendorid);
        public Task<bool> DeleteVendor(int vendorid);
        public Task<VendorResponseDto> GetVendorByNameAsync(string companyname);
    }
}
