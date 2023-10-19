namespace InventApplication.Domain.DTOs
{
    public record ActivityLog
    {
        public string? Comments { get; set; }
        public string? IpAddress { get; set; }
        public int UserId { get; set; }

    }
}
