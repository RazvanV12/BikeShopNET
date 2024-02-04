namespace BikeShopNET.Models
{
    public class UserProfile
    {
        public Guid UserProfileId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
