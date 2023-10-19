namespace InventApplication.Domain.Models
{
    public record DropDownValues
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Field { get; set; }
    }
}
