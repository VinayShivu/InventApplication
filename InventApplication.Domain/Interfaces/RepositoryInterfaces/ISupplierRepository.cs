using InventApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface ISupplierRepository
    {
        public Task<bool> AddSupplier(Supplier supplier);
        public Task<Supplier> GetSupplierByIdAsync(int supplierid);
        public Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        public Task<bool> UpdateSupplier(Supplier supplierUpdate, int supplierid);
        public Task<bool> DeleteSupplier(int supplierid);


    }
}
