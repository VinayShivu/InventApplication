using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Infrastructure.Repositories
{
    internal class SupplierRepository : ISupplierRepository
    {
        public Task<bool> AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSupplier(int supplierid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSupplierByIdAsync(int supplierid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSupplier(Supplier supplierUpdate, int supplierid)
        {
            throw new NotImplementedException();
        }
    }
}
