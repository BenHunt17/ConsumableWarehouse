using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.Domain.Interfaces.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> FindProductCategories();

        ProductCategory AddCategory(ProductCategoryInput input);

        void DeleteCategory(int id);
    }
}
