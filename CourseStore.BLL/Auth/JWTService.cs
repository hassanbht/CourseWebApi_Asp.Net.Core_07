using CourseWebApi.BLL.Infra;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Auth.Entities;
using CourseWebApi.Model.Auth.Queries;
using CourseWebApi.Model.Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CourseWebApi.BLL.JWT
{
    public class JWTService : IAuthService
    {
        private readonly IIdentity _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtOptions _jwtOptions;

        #region Constructor
        public JWTService(IIdentity userManager,
            RoleManager<IdentityRole> roleManager, JwtOptions jwtOptions)
        {
            this._userManager = userManager;
            //this._roleManager = roleManager;
            this._jwtOptions = jwtOptions;
        }


        #endregion

        #region Public Methods

        public async Task<AuthenticationResponse> LoginAsync(LoginCommand user)
        {
            if (string.IsNullOrEmpty(user.UserName))
                return new AuthenticationResponse
                {
                    Message = "Username / password incorrect"
                };
            var currentUser = await _userManager.FindByNameAsync(user.UserName);
            if (currentUser != null && await _userManager.CheckPasswordAsync(currentUser, user.Password!))
            {
                return await GenerateAuthenticationResponseForUserAsync(currentUser);
            }
            return new AuthenticationResponse
            {
                Message = "Username cannot be empty"
            };
        }



        public async Task<AuthenticationResponse> RegisterAsync(CreateUserCommand user)
        {
            var userExists = await _userManager.FindByNameAsync(user.Username!);
            if (userExists != null)
                return new AuthenticationResponse
                {
                    Message = "User with this username already exists"
                };

            ApplicationUser createUser = new()
            {
                Email = user.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = user.Username
            };
            var result = await _userManager.CreateUserAsync(createUser, user.Password);
            if (!result.Succeeded)
            {
                List<string> errors = new List<string>();
                foreach (var item in result.Errors)
                {
                    errors.Add(item.Description);
                }
                return new AuthenticationResponse
                {
                    Message = string.Join(',', errors)
                };
            }
            return await GenerateAuthenticationResponseForUserAsync(createUser);
        }

        public async Task<TokenModel> RefreshTokenAsync(TokenQueriy token)
        {
            if (token is null)
            {
                return new TokenModel
                {
                    Message = "Invalid client request"
                };
            }

            string? accessToken = token.AccessToken;
            string? refreshToken = token.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return new TokenModel
                {
                    Message = "Invalid access token or refresh token"
                };
            }

            string username = principal.Identity?.Name!;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return new TokenModel
                {
                    Message = "Invalid access token or refresh token"
                };
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }


        public async Task<string> RevokeUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return "Invalid user name";

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return string.Empty;
        }

        public async Task RevokeAllAsync()
        {
            var users = await _userManager.GetAllUserAsync();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }

        }

        #endregion

        #region Private Methods

        private async Task<AuthenticationResponse> GenerateAuthenticationResponseForUserAsync(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = CreateToken(authClaims);
            var refreshToken = GenerateRefreshToken();

            _ = int.TryParse(_jwtOptions.RefreshTokenValidityInDays, out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);

            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            _ = int.TryParse(_jwtOptions.TokenValidityInMinutes, out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }



        #endregion
    }

}
