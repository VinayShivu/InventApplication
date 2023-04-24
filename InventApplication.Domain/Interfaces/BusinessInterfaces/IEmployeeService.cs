using InventApplication.Domain.DTOs;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDto> EmployeeDetails();
    }
}
