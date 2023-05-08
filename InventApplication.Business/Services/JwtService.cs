using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.JWT;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using InventApplication.Domain.Models.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InventApplication.Business.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        public JwtService(IConfiguration configuration, IRefreshTokenRepository refreshTokenRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        #region Private
        private static Guid GenerateRefreshToken()
        {
            // extra effort to ensure its a v4 guid
            using var provider = RandomNumberGenerator.Create();
            var bytes = new byte[16];
            provider.GetBytes(bytes);
            bytes[8] = (byte)(bytes[8] & 0xBF | 0x80);
            bytes[7] = (byte)(bytes[7] & 0x4F | 0x40);
            return new Guid(bytes);
        }

        private string GetUserName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                try
                {
                    result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                }
                catch (Exception)
                {
                    throw new RepositoryException(Messages.UserNotAuthorized);
                }
            }
            return result;
        }
        #endregion

        #region Public
        public JwtToken GenerateJwtToken(User user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["JwtSettings:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Roles)
                    }
                ),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:AccessTokenExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken().ToString(),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:RefreshTokenExpirationMinutes"]))
            };

            return new JwtToken
            {
                AccessToken = finaltoken,
                Created = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:AccessTokenExpirationMinutes"])),
                RefreshToken = refreshToken
            };
        }


        public async Task<JwtToken> GetRefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var checkUserLogin = GetUserName();

            var existingRefreshToken = await _refreshTokenRepository.GetRefreshTokenByTokenAsync(refreshTokenRequest.RefreshToken);

            if (existingRefreshToken == null || existingRefreshToken.Expires <= DateTime.Now)
            {
                throw new RepositoryException(Messages.TokenExpired);
            }

            var principal = GetPrincipalFromExpiredToken(refreshTokenRequest.AccessToken);
            var username = principal?.Identity?.Name;
            if (checkUserLogin != username)
            {
                throw new RepositoryException(Messages.InvalidUserClaimName);
            }
            var getuser = _userRepository.GetByUserName(username).Result;
            if (getuser == null)
            {
                throw new RepositoryException(Messages.InvalidToken);
            }
            var jwtToken = GenerateJwtToken(getuser);

            await _refreshTokenRepository.UpdateRefreshTokenAsync(jwtToken, getuser.UserId);

            return jwtToken;
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JwtSettings:Issuer"],
                ValidAudience = _configuration["JwtSettings:Audience"],
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
        #endregion
    }
}
