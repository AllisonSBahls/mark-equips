using MarkEquipsAPI.Data.DTOs;

namespace MarkEquipsAPI.Services
{
    public interface ILoginService
    {
        TokenDto RefreshCredentials(CollaboratorDto collaborator);
        TokenDto RefreshCredentials(TokenDto token);
        bool RevokeToken(string user);
    }
}
