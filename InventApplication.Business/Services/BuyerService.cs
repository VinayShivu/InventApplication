using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;

namespace InventApplication.Business.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;
        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        public async Task<string> AddBuyer(BuyerDto buyer)
        {
            var getbuyer = _buyerRepository.GetBuyerByNameAsync(buyer.BuyerName).Result;
            if (getbuyer == null)
            {
                var newBuyer = new Buyer
                {
                    BuyerName = buyer.BuyerName,
                    BuyerGST = buyer.BuyerGST,
                    Email = buyer.Email,
                    Phone = buyer.Phone,
                    Address = buyer.Address
                };
                var retVal = await _buyerRepository.AddBuyer(newBuyer);

                return retVal ? newBuyer.BuyerName : null;
            }
            else
            {
                throw new RepositoryException(Messages.BuyerExists);
            }
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyerAsync()
        {
            var result = await _buyerRepository.GetAllBuyerAsync();
            if (result == null)
            {
                throw new RepositoryException(Messages.NoData);
            }
            return result.Select(buyer => buyer)
             .Select(buyer => new Buyer
             {
                 BuyerId = buyer.BuyerId,
                 BuyerName = buyer.BuyerName,
                 BuyerGST = buyer.BuyerGST,
                 Email = buyer.Email,
                 Phone = buyer.Phone,
                 Address = buyer.Address
             });
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerid)
        {
            var buyer = await _buyerRepository.GetBuyerByIdAsync(buyerid);
            if (buyer == null)
            {
                throw new RepositoryException(Messages.InvalidBuyerId);
            }
            return buyer;
        }

        public async Task<bool> UpdateBuyer(BuyerDto buyerRequestUpdateDto, int buyerid)
        {
            var buyer = await _buyerRepository.GetBuyerByIdAsync(buyerid);
            if (buyer == null)
            {
                throw new RepositoryException(Messages.InvalidBuyerId);
            }
            else
            {
                buyer.BuyerName = buyerRequestUpdateDto.BuyerName;
                buyer.BuyerGST = buyerRequestUpdateDto.BuyerGST;
                buyer.Email = buyerRequestUpdateDto.Email;
                buyer.Phone = buyerRequestUpdateDto.Phone;
                buyer.Address = buyerRequestUpdateDto.Address;
                var retval = await _buyerRepository.UpdateBuyer(buyer, buyerid);
                return retval;
            }
        }

        public async Task<bool> DeleteBuyer(int buyerid)
        {
            var buyer = await _buyerRepository.GetBuyerByIdAsync(buyerid);
            if (buyer == null)
            {
                throw new RepositoryException(Messages.InvalidBuyerId);
            }
            return await _buyerRepository.DeleteBuyer(buyerid);
        }
    }
}
