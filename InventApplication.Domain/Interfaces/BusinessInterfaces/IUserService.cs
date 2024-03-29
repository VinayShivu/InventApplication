﻿using InventApplication.Domain.DTOs.User;
using InventApplication.Domain.Models.JWT;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IUserService
    {
        public Task<string> RegisterUser(UserDto model);
        public Task<JwtToken> UserLogin(string userName, string password);
        public Task<bool> ForgotPassword(ForgotPasswordRequestDto request);
        public Task<bool> ResetPassword(ResetPasswordRequestDto request);
        public Task<bool> ChangePassword(ChangePasswordRequestDto request);

    }
}
