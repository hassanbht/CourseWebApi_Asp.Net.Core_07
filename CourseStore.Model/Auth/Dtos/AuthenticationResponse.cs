namespace CourseWebApi.Model.Auth.Dtos
{
    public class AuthenticationResponse
    {       
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public string? Message { get; set; }
    }
}
