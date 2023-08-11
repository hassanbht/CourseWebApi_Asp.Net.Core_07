using System.Security.Claims;

namespace CourseWebApi.Model.Framework
{
    public record class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
        public int ExpirationSeconds { get; set; }
        public string SecurityAlgorithm { get; set; }
        public Claim[] Claims { get; set; }
    }
}
