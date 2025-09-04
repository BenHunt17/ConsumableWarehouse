using System.ComponentModel.DataAnnotations;

namespace ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs
{
    public class RegisterPartnerInput
    {
        [Required]
        [StringLength(99, ErrorMessage = "Company name too long")]
        public string CompanyName { get; set; }

        [StringLength(99, ErrorMessage = "Company trading name too long")]
        public string? TradingName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "VAT number too long")]
        public string VatNumber { get; set; }

        [Required]
        [StringLength(99, ErrorMessage = "Contact email too long")]
        [EmailAddress]
        public string ContactEmailAddress { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Contact phone number too long")]
        public string ContactPhoneNumber { get; set; }
    }
}
