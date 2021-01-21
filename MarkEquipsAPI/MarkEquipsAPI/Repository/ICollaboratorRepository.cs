using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public interface ICollaboratorRepository : IRepository<Collaborator>
    {
        Collaborator ValidateCredentials(CollaboratorDto collaborator);
        Collaborator ValidateCredentials(string user);
        Collaborator RefreshUserInfo(Collaborator collaborator);
        bool RevokeToken(string user);
        string ComputeHash(string input, SHA256CryptoServiceProvider algorithm);
    }
}
