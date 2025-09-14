using ConsumableWarehouse.Domain.Entities;

namespace ConsumableWarehouse.WebApp.Data.ProductCategories
{
    public class ProductCategoryForest
    {
        public ProductCategoryForest(IEnumerable<ProductCategory> productCategories)
        {
            ProductCategories = productCategories.Select(x => new ProductCategoryTree(x))
                .ToList();
        }

        public List<ProductCategoryTree> ProductCategories { get; set; }

        public void AddTree(ProductCategoryTree productCategoryTree, int? parentId)
        {
            if (parentId == null)
            {
                ProductCategories.Add(productCategoryTree);
                return;
            }

            foreach(var tree in ProductCategories)
            {
                if (tree.AddTree(productCategoryTree, parentId.Value))
                {
                    return;
                }
            }
        }

        public void RemoveTree(int id)
        {
            foreach (var tree in ProductCategories)
            {
                if (tree.Id == id)
                {
                    ProductCategories.Remove(tree);
                    return;
                }

                if (tree.RemoveTree(id))
                {
                    return;
                }
            }
        }
    }
}
