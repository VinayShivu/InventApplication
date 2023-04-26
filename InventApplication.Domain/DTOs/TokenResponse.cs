namespace InventApplication.Domain.DTOs
{
    public class TokenResponse
    {
        public string? JWTToken { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
    }
}
