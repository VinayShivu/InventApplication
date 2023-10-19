using InventApplication.Domain.DTOs;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IActivityLogRepository
    {
        Task<bool> AddActivityLogAsync(ActivityLog activityLog);
    }
}
