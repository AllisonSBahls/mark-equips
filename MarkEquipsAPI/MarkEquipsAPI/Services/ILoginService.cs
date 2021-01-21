using MarkEquipsAPI.Data.DTOs;

namespace MarkEquipsAPI.Services
{
    public interface ILoginService
    {
        TokenDto ValidateCredentials(CollaboratorDto collaborator);
        TokenDto ValidateCredentials(TokenDto token);
        bool RevokeToken(string user);
    }
}
