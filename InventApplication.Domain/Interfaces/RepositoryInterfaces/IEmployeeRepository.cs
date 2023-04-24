using InventApplication.Domain.DTOs;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<EmployeeDto> EmployeeDetails();
    }
}
