using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategory ToDomainObject(this ProductCategoryInput input)
        {
            return new ProductCategory
            {
                Name = input.Name,
                ParentCategoryId = input.ParentCategoryId,
            };
        }
    }
}
