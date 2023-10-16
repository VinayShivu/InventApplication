using InventApplication.Domain.DTOs.Customer;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<string> AddCustomer(CustomerDto customer)
        {
            var getcustomer = _customerRepository.GetCustomerByNameAsync(customer.CompanyName).Result;
            if (getcustomer == null)
            {
                var newCustomer = new Customer
                {
                    CompanyName = customer.CompanyName,
                    CustomerGST = customer.CustomerGST,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    PrimaryContactName = customer.PrimaryContactName,
                    ContactPersons = customer.ContactPersons
                };
                var retVal = await _customerRepository.AddCustomer(newCustomer);

                return retVal ? newCustomer.CompanyName : null;
            }
            else
            {
                throw new ConflictException(Messages.CustomerExists);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            var result = await _customerRepository.GetAllCustomerAsync();
            if (result == null)
            {
                throw new CustomException(Messages.NoData);
            }
            return result.Select(customer => customer)
             .Select(customer => new Customer
             {
                 CustomerId = customer.CustomerId,
                 CompanyName = customer.CompanyName,
                 CustomerGST = customer.CustomerGST,
                 Email = customer.Email,
                 Phone = customer.Phone,
                 Address = customer.Address,
                 PrimaryContactName = customer.PrimaryContactName,
                 ContactPersons = customer.ContactPersons,
                 Receivables = customer.Receivables
             });
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerid)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerid);
            if (customer == null)
            {
                throw new NotFoundException(Messages.InvalidCustomerId);
            }
            return customer;
        }

        public async Task<Customer> GetCustomerByNameAsync(string companyname)
        {
            var customer = await _customerRepository.GetCustomerByNameAsync(companyname);
            if (customer == null)
            {
                throw new NotFoundException(Messages.InvalidCompanyName);
            }
            return customer;
        }

        public async Task<bool> UpdateCustomer(CustomerDto customerRequestUpdateDto, int customerid)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerid);
            if (customer == null)
            {
                throw new NotFoundException(Messages.InvalidCustomerId);
            }
            var getcustomer = _customerRepository.GetCustomerByNameAsync(customerRequestUpdateDto.CompanyName).Result;
            if (getcustomer != null && getcustomer.CustomerId != customerid)
            {
                throw new ConflictException(Messages.CustomerExists);
            }
            customer.CompanyName = customerRequestUpdateDto.CompanyName;
            customer.CustomerGST = customerRequestUpdateDto.CustomerGST;
            customer.Email = customerRequestUpdateDto.Email;
            customer.Phone = customerRequestUpdateDto.Phone;
            customer.Address = customerRequestUpdateDto.Address;
            customer.PrimaryContactName = customerRequestUpdateDto.PrimaryContactName;
            customer.ContactPersons = customerRequestUpdateDto.ContactPersons;
            var retval = await _customerRepository.UpdateCustomer(customer, customerid);
            return retval;
        }

        public async Task<bool> DeleteCustomer(int customerid)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerid);
            if (customer == null)
            {
                throw new NotFoundException(Messages.InvalidCustomerId);
            }
            return await _customerRepository.DeleteCustomer(customerid);
        }
    }
}
