using InventApplication.Domain.Models;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IDropdownRepository
    {
        Task<List<DropDownValues>> GetDropDownListAsync();
    }
}
