namespace ConsumableWarehouse.Application.Authentication
{
    public class UserContext
    {
        //For now I am simply mocking the UserProfileId so I can integrate it with the features I am implementing.
        //When authentication is implemented, this would be changed to dynamically set the Id of whoever is authenticated.
        public int UserProfileId { get; set; } = 1;
    }
}
