using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        public Task<bool> AddCustomer(Customer customer);
        public Task<Customer> GetCustomerByIdAsync(int customerid);
        public Task<IEnumerable<Customer>> GetAllCustomerAsync();
        public Task<bool> UpdateCustomer(Customer customerUpdate, int customerid);
        public Task<bool> DeleteCustomer(int customerid);
        public Task<Customer> GetCustomerByNameAsync(string customername);
    }
}
