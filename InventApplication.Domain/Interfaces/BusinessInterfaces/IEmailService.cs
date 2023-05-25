namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IEmailService
    {
        public Task<bool> SendPasswordResetEmail(string email, string token);
    }
}
