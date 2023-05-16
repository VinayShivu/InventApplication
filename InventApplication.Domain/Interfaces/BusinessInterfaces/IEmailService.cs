namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string subject, string body);
    }
}
