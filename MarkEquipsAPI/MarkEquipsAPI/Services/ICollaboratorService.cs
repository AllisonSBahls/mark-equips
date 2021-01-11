using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services
{
    public interface ICollaboratorService
    {
        Collaborator Create(Collaborator collaborator);
        Collaborator FindByID(int id);
        List<Collaborator> FindAll();
        Collaborator Update(Collaborator collaborator);
        void Delete(int id);

    }
}
