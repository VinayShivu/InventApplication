using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
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

        public async Task<IEnumerable<SupplierDto>> GetAllSupplierAsync()
        {
            var result = await _supplierRepository.GetAllSupplierAsync();

            return result.Select(supplier => supplier)
          .Select(supplier => new SupplierDto
          {
              SupplierId = supplier.SupplierId,
              SupplierName = supplier.SupplierName,
              SupplierGST = supplier.SupplierGST,
              Email = supplier.Email,
              Phone = supplier.Phone,
              Address = supplier.Address
          });
        }

        public async Task<Supplier> GetSupplierByIdAsync(int supplierid)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(supplierid);
            if (supplier == null)
            {
                throw new RepositoryException(Messages.InvalidSupplierId);
            }
            return supplier;
        }

        public async Task<bool> UpdateSupplier(SupplierDto supplierRequestUpdateDto, int supplierid)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(supplierid);
            if (supplier == null)
            {
                throw new RepositoryException(Messages.InvalidSupplierId);
            }
            else
            {
                supplier.SupplierName = supplierRequestUpdateDto.SupplierName;
                supplier.SupplierGST = supplierRequestUpdateDto.SupplierGST;
                supplier.Email = supplierRequestUpdateDto.Email;
                supplier.Phone = supplierRequestUpdateDto.Phone;
                supplier.Address = supplierRequestUpdateDto.Address;
                var retval = await _supplierRepository.UpdateSupplier(supplier, supplierid);
                return retval;
            }
        }

        public async Task<bool> DeleteSupplier(int supplierid)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(supplierid);
            if (supplier == null)
            {
                throw new RepositoryException(Messages.InvalidSupplierId);
            }
            return await _supplierRepository.DeleteSupplier(supplierid);
        }
    }
}
