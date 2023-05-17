using InventApplication.Domain.DTOs;
using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface ICustomerService
    {
        public Task<string> AddCustomer(CustomerDto customer);
        public Task<Customer> GetCustomerByIdAsync(int customerid);
        public Task<IEnumerable<Customer>> GetAllCustomerAsync();
        public Task<bool> UpdateCustomer(CustomerDto customerRequestUpdateDto, int customerid);
        public Task<bool> DeleteCustomer(int customerid);
        public Task<Customer> GetCustomerByNameAsync(string companyname);
    }
}
