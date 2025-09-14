using ConsumableWarehouse.Domain.Dtos.Form.PartnerInputs;
using ConsumableWarehouse.Domain.Entities;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.Domain.Mappers;
using ConsumableWarehouse.Domain.Validators.ProductCategory;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ConsumableWarehouse.Application.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IDataContext _dataContext;

        public ProductCategoryService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<ProductCategory> FindProductCategories()
        {
            var categories = _dataContext.ProductCategories.ToList();

            var lookup = categories.ToLookup(x => x.ParentCategoryId);
            foreach (var category in categories)
            {
                category.ChildCategories = lookup[category.Id].ToList();
            }

            return categories;
        }

        public ProductCategory AddCategory(ProductCategoryInput input)
        {
            new ProductCategoryInputValidator().ValidateAndThrow(input);

            if (input.ParentCategoryId != null)
            {
                var parentCategory = _dataContext.ProductCategories
                    .FirstOrDefault(x => x.Id == input.ParentCategoryId);

                if (parentCategory == null)
                {
                    throw new KeyNotFoundException("Parent category not found");
                }
            }

            var productCategory = input.ToDomainObject();

            _dataContext.ProductCategories.Add(productCategory);

            _dataContext.Commit();

            return productCategory;
        }

        public void DeleteCategory(int id)
        {
            var allCategories = _dataContext.ProductCategories.ToList();
            
            var category = allCategories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            RemoveCategoryAndDescendants(category);

            _dataContext.Commit();
        }

        private void RemoveCategoryAndDescendants(ProductCategory productCategory)
        {
            if (productCategory.ChildCategories != null)
            {
                foreach (var child in productCategory.ChildCategories)
                {
                    RemoveCategoryAndDescendants(child);
                }
            }

            _dataContext.ProductCategories.Remove(productCategory);
        }
    }
}
