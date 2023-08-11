using CourseWebApi.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.BLL.Infra
{
    public interface IAuthService
    {
        string SecretKey { get; set; }

        bool IsTokenValid(string token);
        string GenerateToken(JwtOptions options);
        IEnumerable<Claim> GetTokenClaims(string token);

    }
}
