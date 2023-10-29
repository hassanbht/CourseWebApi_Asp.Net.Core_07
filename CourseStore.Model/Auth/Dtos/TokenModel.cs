using MediatR;

namespace CourseWebApi.Model.Auth.Dtos
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? Message { get; set; }
    }
}
