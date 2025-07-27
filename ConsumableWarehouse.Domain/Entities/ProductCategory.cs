namespace ConsumableWarehouse.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public ProductCategory? ParentCategory { get; set; }

        public ICollection<ProductCategory> ChildCategories { get; set; }

        public ICollection<AffiliateProduct> AffiliateProducts { get; set; }
    }
}
