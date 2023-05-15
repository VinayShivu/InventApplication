using InventApplication.Domain.DTOs;
using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Helpers;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.JWT;
using InventApplication.Domain.Interfaces.Password;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using InventApplication.Domain.Models.JWT;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;

namespace InventApplication.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;


        public UserService(IUserRepository userRepository, IPasswordService passwordService, IJwtService jwtService, IRefreshTokenRepository refreshTokenRepository, IEmailService emailService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
            _emailService = emailService;
            _configuration = configuration;
        }

        #region Private
        private static Guid GeneratePasswordResetToken()
        {
            // extra effort to ensure its a v4 guid
            using var provider = RandomNumberGenerator.Create();
            var bytes = new byte[16];
            provider.GetBytes(bytes);
            bytes[8] = (byte)(bytes[8] & 0xBF | 0x80);
            bytes[7] = (byte)(bytes[7] & 0x4F | 0x40);
            return new Guid(bytes);
        }

        private async Task<bool> SendPasswordResetEmail(string email, string token)
        {
            // Compose the password reset email with a link containing the token
            var domainname = _configuration["DNS:applicationUrl"];
            var resetLink = $"{domainname}/resetpassword?token={token}";
            var emailBody = $"Click the link below to reset your password:<br><a href=\"{resetLink}\">{resetLink}</a>";

            // Send the email using the email service
            var emailSent = await _emailService.SendEmail(email, "Password Reset", emailBody);

            return emailSent;
        }
        #endregion

        public void RegisterUser(UserDto model)
        {
            var getuser = _userRepository.GetByUserName(model.Username).Result;
            if (getuser == null)
            {
                var user = new UserDto
                {
                    Username = model.Username,
                    Password = _passwordService.HashPassword(model.Password),
                    Email = model.Email,
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

        public async Task<bool> ForgotPassword(ForgotPasswordRequestDto request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email) ?? throw new RepositoryException(Messages.InvalidEmail);
            var token = GeneratePasswordResetToken().ToString();
            var passwordresettokenexpires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:PasswordResetTokenExpirationMinutes"]));
            await _userRepository.UpdatePasswordResetToken( token, user.UserId, passwordresettokenexpires);

            var emailSent = await SendPasswordResetEmail(user.Email, token);
            if (!emailSent)
            {
                throw new RepositoryException(Messages.FailedPasswordResetEmail);
            }
            return emailSent;
        }

        public async Task<bool> ResetPassword(ResetPasswordRequestDto request)
        {
            var user = await _userRepository.GetUserByPasswordResetToken(request.PasswordResetToken) ?? throw new RepositoryException(Messages.UserNotFound);
            if (user == null || user.PasswordResetTokenExpires <= DateTime.Now)
            {
                throw new RepositoryException(Messages.PasswordResetTokenExpired);
            }
            var newpassword = _passwordService.HashPassword(request.NewPassword);
            var result = await _userRepository.UpdatePassword(user.UserId, newpassword);
            return result;
        }
    }
}
