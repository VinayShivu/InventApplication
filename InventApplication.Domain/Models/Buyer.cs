using System.ComponentModel.DataAnnotations;

namespace InventApplication.Domain.Models
{
    public class Buyer
    {
        [Key]
        [Required]
        public int BuyerId { get; set; }

        [Required(ErrorMessage = "Please enter a Buyer Name.")]
        public string BuyerName { get; set; }

        [Required(ErrorMessage = "Please enter a Buyer GST.")]
        public string BuyerGST { get; set; }

        [Required(ErrorMessage = "Please enter a Buyer Phone Number.")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
