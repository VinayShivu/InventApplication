using InventApplication.Domain.DTOs.Vendor;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Newtonsoft.Json;

namespace InventApplication.Business.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        public async Task<string> AddVendor(VendorRequestDto vendor)
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
                    Address = JsonConvert.SerializeObject(vendor.Address),
                    PrimaryContactName = vendor.PrimaryContactName,
                    ContactPersons = JsonConvert.SerializeObject(vendor.ContactPersons),
                    Remarks = vendor.Remarks
                };
                bool retVal = await _vendorRepository.AddVendor(newVendor);

                return retVal ? newVendor.CompanyName : null;
            }
            else
            {
                throw new ConflictException(Messages.VendorExists);
            }
        }

        public async Task<IEnumerable<VendorResponseDto>> GetAllVendorAsync()
        {
            var result = await _vendorRepository.GetAllVendorAsync();
            if (result == null)
            {
                throw new CustomException(Messages.NoData);
            }
            return result.Select(vendor => vendor)
             .Select(vendor => new VendorResponseDto
             {
                 VendorId = vendor.VendorId,
                 CompanyName = vendor.CompanyName,
                 VendorGST = vendor.VendorGST,
                 Email = vendor.Email,
                 Phone = vendor.Phone,
                 Address = JsonConvert.DeserializeObject<Address>(vendor.Address),
                 PrimaryContactName = vendor.PrimaryContactName,
                 ContactPersons = JsonConvert.DeserializeObject<List<ContactPersons>>(vendor.ContactPersons),
                 Payables = vendor.Payables,
                 Remarks = vendor.Remarks
             });
        }

        public async Task<VendorResponseDto> GetVendorByIdAsync(int vendorid)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(vendorid);
            if (vendor == null)
            {
                throw new NotFoundException(Messages.InvalidVendorId);
            }
            var result = new VendorResponseDto
            {
                VendorId = vendor.VendorId,
                CompanyName = vendor.CompanyName,
                VendorGST = vendor.VendorGST,
                Email = vendor.Email,
                Phone = vendor.Phone,
                Address = JsonConvert.DeserializeObject<Address>(vendor.Address),
                PrimaryContactName = vendor.PrimaryContactName,
                ContactPersons = JsonConvert.DeserializeObject<List<ContactPersons>>(vendor.ContactPersons),
                Payables = vendor.Payables,
                Remarks = vendor.Remarks
            };
            return result;
        }

        public async Task<VendorResponseDto> GetVendorByNameAsync(string companyname)
        {
            var vendor = await _vendorRepository.GetVendorByNameAsync(companyname);
            if (vendor == null)
            {
                throw new NotFoundException(Messages.InvalidCompanyName);
            }
            var result = new VendorResponseDto
            {
                VendorId = vendor.VendorId,
                CompanyName = vendor.CompanyName,
                VendorGST = vendor.VendorGST,
                Email = vendor.Email,
                Phone = vendor.Phone,
                Address = JsonConvert.DeserializeObject<Address>(vendor.Address),
                PrimaryContactName = vendor.PrimaryContactName,
                ContactPersons = JsonConvert.DeserializeObject<List<ContactPersons>>(vendor.ContactPersons),
                Payables = vendor.Payables,
                Remarks = vendor.Remarks
            };
            return result;
        }

        public async Task<bool> UpdateVendor(VendorRequestDto vendorRequestUpdateDto, int vendorid)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(vendorid);
            if (vendor == null)
            {
                throw new NotFoundException(Messages.InvalidVendorId);
            }
            var getvendor = _vendorRepository.GetVendorByNameAsync(vendorRequestUpdateDto.CompanyName).Result;
            if (getvendor != null && getvendor.VendorId != vendorid)
            {
                throw new ConflictException(Messages.VendorExists);
            }
            vendor.CompanyName = vendorRequestUpdateDto.CompanyName;
            vendor.VendorGST = vendorRequestUpdateDto.VendorGST;
            vendor.Email = vendorRequestUpdateDto.Email;
            vendor.Phone = vendorRequestUpdateDto.Phone;
            vendor.Address = JsonConvert.SerializeObject(vendorRequestUpdateDto.Address);
            vendor.PrimaryContactName = vendorRequestUpdateDto.PrimaryContactName;
            vendor.ContactPersons = JsonConvert.SerializeObject(vendorRequestUpdateDto.ContactPersons);
            vendor.Remarks = vendorRequestUpdateDto.Remarks;
            bool retval = await _vendorRepository.UpdateVendor(vendor, vendorid);
            return retval;
        }

        public async Task<bool> DeleteVendor(int vendorid)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(vendorid);
            if (vendor == null)
            {
                throw new NotFoundException(Messages.InvalidVendorId);
            }
            return await _vendorRepository.DeleteVendor(vendorid);
        }
    }
}
