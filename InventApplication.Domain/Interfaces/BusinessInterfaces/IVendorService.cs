using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IVendorService
    {
        public Task<string> AddVendor(VendorDto vendor);
        public Task<Vendor> GetVendorByIdAsync(int vendorid);
        public Task<IEnumerable<Vendor>> GetAllVendorAsync();
        public Task<bool> UpdateVendor(VendorDto vendorRequestUpdateDto, int vendorid);
        public Task<bool> DeleteVendor(int vendorid);
    }
}
