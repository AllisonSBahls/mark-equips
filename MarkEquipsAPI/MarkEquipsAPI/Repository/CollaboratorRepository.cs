using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository.Context;
using MarkEquipsAPI.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public class CollaboratorRepository : GenericRepository<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(MarkEquipsContext context) : base(context) { }

        public Collaborator ValidateCredentials(CollaboratorDto collaborator)
        {
            var pass = ComputeHash(collaborator.Password, new SHA256CryptoServiceProvider());
            return _context.Collaborators.FirstOrDefault(u => (u.User == collaborator.User) && (u.Password == pass));
        }

        public Collaborator ValidateCredentials(string user)
        {
            return _context.Collaborators.SingleOrDefault(u => (u.User == user));
        }

        public Collaborator RefreshUserInfo(Collaborator collaborator)
        {
            if (!_context.Collaborators.Any(e => e.Id.Equals(collaborator.Id))) return null;
            var result = _context.Collaborators.SingleOrDefault(p => p.Id.Equals(collaborator.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(collaborator);
                    _context.SaveChangesAsync();
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception("Error in: " + e.Message);
                }
            }
            return result;
        }
        public bool RevokeToken(string user)
        {
            var userToken = _context.Collaborators.SingleOrDefault(u => (u.User == user));
            if (userToken is null) return false;
            userToken.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
        public string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}