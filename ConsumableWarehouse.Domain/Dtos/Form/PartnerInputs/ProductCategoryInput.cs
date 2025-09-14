using System.ComponentModel.DataAnnotations;

namespace ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs
{
    public class ProductCategoryInput
    {
        [Required]
        [StringLength(99, ErrorMessage = "Category name too long")]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
