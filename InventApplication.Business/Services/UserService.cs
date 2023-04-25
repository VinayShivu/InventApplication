using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.Password;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventApplication.Business.Services
{
    public class UserService : IUserService
    {
        public IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IConfiguration configuration, IUserRepository userRepository, IPasswordService passwordService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        private string GenerateToken(UserDto userInfo)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userInfo.userId.ToString()),
                        new Claim(ClaimTypes.Name, userInfo.Username),
                    }
                ),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            tokenResponse.JWTToken = finaltoken;

            return tokenResponse.JWTToken;
        }

        public void RegisterUser(UserDto model)
        {
            if (_userRepository.GetByUserName(model.Username) != null)
            {
                throw new RepositoryException(Messages.UserExists);
            }
            var user = new UserDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = _passwordService.HashPassword(model.Password)
            };
            _userRepository.RegisterUser(user);
        }

        public string UserLogin(string userName, string password)
        {
            string token = string.Empty;
            if (userName != null && password != null)
            {
                var user = _userRepository.GetByUserName(userName);
                if (user != null)
                {
                    var verifiedpassword = _passwordService.VerifyPassword(password, user.Password);
                    if (!verifiedpassword)
                    {
                        throw new RepositoryException(Messages.InvalidPassword);
                    }

                    token = GenerateToken(user);
                }
                else
                {
                    token = "Invalid Credentials";
                }
            }
            return token;
        }

    }
}
