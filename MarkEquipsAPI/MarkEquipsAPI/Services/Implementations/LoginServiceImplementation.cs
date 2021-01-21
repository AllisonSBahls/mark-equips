using MarkEquipsAPI.Configurations;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Helpers;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class LoginServiceImplementation : ILoginService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private readonly TokenConfiguration _configuration;
        private readonly ICollaboratorRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginServiceImplementation(TokenConfiguration configuration, ICollaboratorRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenDto ValidateCredentials(CollaboratorDto collaborator)
        {
            var user = _repository.ValidateCredentials(collaborator);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.User)
            };

            var accessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpityTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            var refreshUser = RefreshUser(user, accessToken, refreshToken);
            return refreshUser;
        }

        public TokenDto ValidateCredentials(TokenDto token)
        {
             
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _repository.ValidateCredentials(username);
            if (user == null ||
                user.RefreshToken != refreshToken || 
                user.RefreshTokenExpityTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAcessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            var refreshUser = RefreshUser(user, accessToken, refreshToken);
            return refreshUser;
        }

        public TokenDto RefreshUser(Collaborator user, string accessToken, string refreshToken)
        {
            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDto(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public bool RevokeToken(string user)
        {
            return _repository.RevokeToken(user);
        }
    }
}
