using System.Security.Claims;

namespace CourseWebApi.Model.Framework
{
    public record class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public string TokenValidityInMinutes { get; set; }
        public string RefreshTokenValidityInDays { get; set; }
        public Claim[] Claims { get; set; }
    }
}
