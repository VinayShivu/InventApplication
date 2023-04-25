namespace InventApplication.Domain.DTOs
{
    public class TokenResponse
    {
        public string? JWTToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
