﻿using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
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

        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public void RegisterUser(UserDto model)
        {
            _userRepository.RegisterUser(model);
        }

        public string UserLogin(string userName, string password)
        {
            string token = string.Empty;
            if (userName != null && password != null)
            {
                var user = _userRepository.GetByUser(userName, password);
                if (user != null)
                {
                    token = GenerateToken(user);
                }
                else
                {
                    token = "Invalid Credentials";
                }
            }
            return token;
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
    }
}
