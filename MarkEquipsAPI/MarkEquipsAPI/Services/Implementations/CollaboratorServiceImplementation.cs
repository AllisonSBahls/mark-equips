using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class CollaboratorServiceImplementation : ICollaboratorService
    {
        private readonly IRepository<Collaborator> _repository;

        public CollaboratorServiceImplementation(IRepository<Collaborator> repository)
        {
            _repository = repository;
        }

        public Collaborator Create(Collaborator collaborator)
        {
            return _repository.Create(collaborator);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Collaborator> FindAll()
        {
            return _repository.FindAll();
        }

        public Collaborator FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Collaborator Update(Collaborator collaborator)
        {
            return _repository.Update(collaborator);
        }
    }
}
