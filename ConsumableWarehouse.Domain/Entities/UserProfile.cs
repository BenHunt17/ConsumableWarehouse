namespace ConsumableWarehouse.Domain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

        //Would be the ID used for some external authentication provider. For now it's just mocked.
        public string UserIdentityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Wishlist> wishlists { get; set; }
    }
}
