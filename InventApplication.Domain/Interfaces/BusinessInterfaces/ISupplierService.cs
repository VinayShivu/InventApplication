using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface ISupplierService
    {
        public Task<string> AddSupplier(SupplierDto supplier);
        public Task<Supplier> GetSupplierByIdAsync(int supplierid);
        public Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        public Task<bool> UpdateSupplier(SupplierDto supplierRequestUpdateDto, int supplierid);
        public Task<bool> DeleteSupplier(int supplierid);
    }
}
