using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Configuration.Auth;
using SiteManagement.Business.Configuration.Response;
using SiteManagement.DAL.Abstract;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiteManagement.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        private readonly IConfiguration _configuration;

        private readonly IDistributedCache _distributedCache;

        public AuthService(IUserRepository userRepository,
            IConfiguration configuration, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _distributedCache = distributedCache;
        }

        public CommandResponse VerifyPassword(string email, string password)
        {
            var entity = _userRepository.GetUserWithPassword(email);

            if (entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Message = "Epostanız hatalı"
                };
            }

            if (HashHelper.VerifyPasswordHash(password, entity.UserPassword.PasswordHash, entity.UserPassword.PasswordSalt))
            {
                return new CommandResponse()
                {
                    Status = true,
                    Message = "Şifre doğru"
                };
            }

            return new CommandResponse()
            {
                Status = false,
                Message = "Şifre hatalı"
            };
        }

        public CommandResponse Login(string email, string password)
        {
            #region Token

            var respoonse = VerifyPassword(email, password);

            if (respoonse.Status)
            {
                var user = _userRepository.GetUserWithBlock(email);

                var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();

                var expireDate = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.Role, ((int)user.UserRole).ToString()),
                    new Claim("SiteId", ((int)user.Flat.Block.SiteId).ToString())
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    claims: claims,
                    expires: expireDate,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                #endregion

                #region Cache
                //kullanıcının id ile USR_kullanıcıID key oluşup token kaydedilecek
                _distributedCache.SetString($"USR_{user.Id}", token);

                #endregion
                var accessToken = new AccessToken()
                {
                    Token = token,
                    ExpireDate = expireDate
                };

                return new CommandResponse
                {
                    Status = true,
                    Data = accessToken
                };
            }

            return new CommandResponse()
            {
                Message = "Login işlemi başarısız"
            };
        }
    }
}
