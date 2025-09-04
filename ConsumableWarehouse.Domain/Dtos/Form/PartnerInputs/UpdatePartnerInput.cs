using ConsumableWarehouse.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs
{
    public class UpdatePartnerInput
    {
        public UpdatePartnerInput(Partner partner)
        {
            TradingName = partner.TradingName;
            ContactEmailAddress = partner.ContactEmailAddress;
            ContactPhoneNumber = partner.ContactPhoneNumber;
        }

        [StringLength(99, ErrorMessage = "Company trading name too long")]
        public string? TradingName { get; set; }

        [Required]
        [StringLength(99, ErrorMessage = "Contact email too long")]
        [EmailAddress]
        public string ContactEmailAddress { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Contact phone number too long")]
        public string ContactPhoneNumber { get; set; }
    }
}
