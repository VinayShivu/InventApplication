namespace InventApplication.Domain.DTOs.Dropdowns
{
    public record DropDownValuesDto
    {
        public List<Common>? VendorName { get; set; }

    }
    public record Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
