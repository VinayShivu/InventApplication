using InventApplication.Business.Services;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Infrastructure.Common;
using InventApplication.Infrastructure.Repositories;
using InventApplication.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace InventApplication.IOC
{
    public static class UserRegisterIOC
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
        }
    }
}