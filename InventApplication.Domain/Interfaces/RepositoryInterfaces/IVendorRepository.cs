using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IVendorRepository
    {
        public Task<bool> AddVendor(Vendor vendor);
        public Task<Vendor> GetVendorByIdAsync(int vendorid);
        public Task<IEnumerable<Vendor>> GetAllVendorAsync();
        public Task<bool> UpdateVendor(Vendor vendorUpdate, int vendorid);
        public Task<bool> DeleteVendor(int vendorid);
        public Task<Vendor> GetVendorByNameAsync(string companyname);

    }
}
