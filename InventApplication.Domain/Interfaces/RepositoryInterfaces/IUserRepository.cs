﻿using InventApplication.Domain.DTOs;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public void RegisterUser(UserDto model);

        public UserDto GetByUser(string username, string password);

        public Task<UserDto> GetByUserName(string username);
    }
}
