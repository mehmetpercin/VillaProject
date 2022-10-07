namespace VillaProject.Application.Dtos.Identities
{
    public class AuthResponse
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
