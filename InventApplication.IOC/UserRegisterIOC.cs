using Microsoft.Extensions.DependencyInjection;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Business.Services;
using InventApplication.Repository.Repositories;

namespace InventApplication.IOC
{
    public static class UserRegisterIOC
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}