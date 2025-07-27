namespace ConsumableWarehouse.Domain.Entities
{
    public class Partner
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactEmailAddress { get; set; }

        public string ContactPhoneNumber { get; set; }

        public ICollection<AffiliateProduct> AffiliateProducts { get; set; }
    }
}
