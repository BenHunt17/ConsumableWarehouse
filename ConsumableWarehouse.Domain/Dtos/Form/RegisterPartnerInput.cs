using System.ComponentModel.DataAnnotations;

namespace ConsumableWarehouse.Domain.Dtos.Form
{
    public class RegisterPartnerInput
    {
        [Required]
        [StringLength(99, ErrorMessage = "Company name too long")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(99, ErrorMessage = "Contact email too long")]
        [EmailAddress]
        public string ContactEmailAddress { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Contact phone number too long")]
        public string ContactPhoneNumber { get; set; }
    }
}
