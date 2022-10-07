namespace VillaProject.Identity.Entities
{
    public class UserRefreshToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
