using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.WebApp.Data.ProductCategories
{
    public class ProductCategoryTree
    {
        public ProductCategoryTree(ProductCategory productCategory)
        {
            Id = productCategory.Id;
            Name = productCategory.Name;
            SubCategories = productCategory.ChildCategories
                ?.Select(x => new ProductCategoryTree(x))
                ?.ToList() ?? new List<ProductCategoryTree>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductCategoryTree> SubCategories { get; set; }

        public bool AddTree(ProductCategoryTree productCategoryTree, int? parentId)
        {
            if (Id == parentId)
            {
                SubCategories.Add(productCategoryTree);
                return true;
            }

            foreach (var tree in SubCategories)
            {
                if (tree.AddTree(productCategoryTree, parentId))
                {
                    return true;
                }
            }

            return false;
        }

        public bool RemoveTree(int id)
        {
            for (int i = SubCategories.Count - 1; i >= 0; i--)
            {
                if (SubCategories[i].Id == id)
                {
                    SubCategories.RemoveAt(i);
                    return true;
                }

                if (SubCategories[i].RemoveTree(id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
