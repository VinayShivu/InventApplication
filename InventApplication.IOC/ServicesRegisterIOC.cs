﻿using InventApplication.Business.Services;
using InventApplication.Business.Services.Password;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.JWT;
using InventApplication.Domain.Interfaces.Password;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Infrastructure.Common;
using InventApplication.Infrastructure.Repositories;
using InventApplication.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InventApplication.IOC
{
    public static class ServicesRegisterIOC
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<IVendorService, VendorService>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IItemsService, ItemsService>();
            services.AddTransient<IItemsRepository, ItemsRepository>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddTransient<IDropdownService, DropdownService>();
            services.AddTransient<IDropdownRepository, DropdownRepository>();
            services.AddTransient<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();
            services.AddTransient<IActivityLogRepository, ActivityLogRepository>();
        }
    }
}