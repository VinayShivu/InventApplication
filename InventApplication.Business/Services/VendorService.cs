using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<string> AddVendor(VendorDto vendor)
        {
            var getvendor = _vendorRepository.GetVendorByNameAsync(vendor.CompanyName).Result;
            if (getvendor == null)
            {
                var newVendor = new Vendor
                {
                    CompanyName = vendor.CompanyName,
                    VendorGST = vendor.VendorGST,
                    Email = vendor.Email,
                    Phone = vendor.Phone,
                    Address = vendor.Address,
                    PrimaryContactName = vendor.PrimaryContactName,
                    ContactPersons = vendor.ContactPersons,
                };
                var retVal = await _vendorRepository.AddVendor(newVendor);

                return retVal ? newVendor.CompanyName : null;
            }
            else
            {
                throw new RepositoryException(Messages.VendorExists);
            }
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorAsync()
        {
            var result = await _vendorRepository.GetAllVendorAsync();
            if (result == null)
            {
                throw new RepositoryException(Messages.NoData);
            }
            return result.Select(vendor => vendor)
             .Select(vendor => new Vendor
             {
                 VendorId = vendor.VendorId,
                 CompanyName = vendor.CompanyName,
                 VendorGST = vendor.VendorGST,
                 Email = vendor.Email,
                 Phone = vendor.Phone,
                 Address = vendor.Address,
                 PrimaryContactName = vendor.PrimaryContactName,
                 ContactPersons = vendor.ContactPersons,
                 Payables = vendor.Payables
             });
        }

        public async Task<Vendor> GetVendorByIdAsync(int vendorid)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(vendorid);
            if (vendor == null)
            {
                throw new RepositoryException(Messages.InvalidVendorId);
            }
            return vendor;
        }

        public async Task<Vendor> GetVendorByNameAsync(string companyname)
        {
            var vendor = await _vendorRepository.GetVendorByNameAsync(companyname);
            if (vendor == null)
            {
                throw new RepositoryException(Messages.InvalidCompanyName);
            }
            return vendor;
        }

        public async Task<bool> UpdateVendor(VendorDto vendorRequestUpdateDto, int vendorid)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(vendorid);
            if (vendor == null)
            {
                throw new RepositoryException(Messages.InvalidVendorId);
            }
            var getvendor = _vendorRepository.GetVendorByNameAsync(vendorRequestUpdateDto.CompanyName).Result;
            if (getvendor != null && getvendor.VendorId != vendorid)
            {
                throw new RepositoryException(Messages.VendorExists);
            }
            vendor.CompanyName = vendorRequestUpdateDto.CompanyName;
            vendor.VendorGST = vendorRequestUpdateDto.VendorGST;
            vendor.Email = vendorRequestUpdateDto.Email;
            vendor.Phone = vendorRequestUpdateDto.Phone;
            vendor.Address = vendorRequestUpdateDto.Address;
            vendor.PrimaryContactName = vendorRequestUpdateDto.PrimaryContactName;
            vendor.ContactPersons = vendorRequestUpdateDto.ContactPersons;
            var retval = await _vendorRepository.UpdateVendor(vendor, vendorid);
            return retval;
        }

        public async Task<bool> DeleteVendor(int vendorid)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(vendorid);
            if (vendor == null)
            {
                throw new RepositoryException(Messages.InvalidVendorId);
            }
            return await _vendorRepository.DeleteVendor(vendorid);
        }
    }
}
