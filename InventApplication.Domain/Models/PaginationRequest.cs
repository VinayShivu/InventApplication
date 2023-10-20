using System.ComponentModel;

namespace InventApplication.Domain.Models
{
    public record PaginationRequest
    {
        [DefaultValue("Id")]
        public string? SortField { get; set; }
        [DefaultValue("ASC")]
        public string? SortOrder { get; set; }
        public string? FilterChar { get; set; }
        public string? SearchStr { get; set; }
        [DefaultValue(1)]
        public Int64 PageNo { get; set; }
        [DefaultValue(2147483647)]
        public Int64 PageSize { get; set; }
    }
}
