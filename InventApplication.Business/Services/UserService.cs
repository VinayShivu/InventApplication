using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.JWT;
using InventApplication.Domain.Interfaces.Password;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models.JWT;

namespace InventApplication.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;


        public UserService(IUserRepository userRepository, IPasswordService passwordService, IJwtService jwtService, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public void RegisterUser(UserDto model)
        {
            var getuser = _userRepository.GetByUserName(model.Username).Result;
            if (getuser == null)
            {
                var user = new UserDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Password = _passwordService.HashPassword(model.Password),
                    Roles = model.Roles
                };
                _userRepository.RegisterUser(user);
            }
            else
            {
                throw new RepositoryException(Messages.UserExists);
            }
        }

        public async Task<JwtToken> UserLogin(string userName, string password)
        {
            JwtToken jwtToken = new JwtToken();
            if (userName != null && password != null)
            {
                var user = await _userRepository.GetByUserName(userName);
                if (user == null)
                {
                    throw new RepositoryException(Messages.InvalidUsername);
                }
                var verifiedpassword = _passwordService.VerifyPassword(password, user.Password);
                if (!verifiedpassword)
                {
                    throw new RepositoryException(Messages.InvalidPassword);
                }

                jwtToken = _jwtService.GenerateJwtToken(user);

                await _refreshTokenRepository.UpdateRefreshTokenAsync(jwtToken, user.UserId);
            }
            return jwtToken;
        }
    }
}
