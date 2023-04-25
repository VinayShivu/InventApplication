using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<string> AddSupplier(SupplierDto supplier)
        {
            var newSupplier = new Supplier
            {
                SupplierName = supplier.SupplierName,
                SupplierGST = supplier.SupplierGST,
                Email = supplier.Email,
                Phone = supplier.Phone,
                Address = supplier.Address
            };
            var retVal = await _supplierRepository.AddSupplier(newSupplier);

            return retVal ? newSupplier.SupplierName : null;
        }

        public Task<bool> DeleteSupplier(int supplierid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierDto>> GetAllSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSupplierByIdAsync(int supplierid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSupplier(SupplierDto supplierRequestUpdateDto, int supplierid)
        {
            throw new NotImplementedException();
        }
    }
}
