namespace InventApplication.Domain.Models.JWT
{
    public record JwtToken
    {
        public string? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public User? UserData { get; set; }
    }
}
