using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services.Implementations
{
    public class ReserverServiceImplementation : IReserverService
    {
        private readonly IRepository<Reserver> _repository;

        public ReserverServiceImplementation(IRepository<Reserver> repository)
        {
            _repository = repository;
        }

        public List<Reserver> FindAll()
        {
            return _repository.FindAll();
        }

        public Reserver FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Reserver Create(Reserver reserver)
        {
            
            return _repository.Create(reserver);
        }

        public Reserver Update(Reserver reserver)
        {
            return _repository.Update(reserver);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
      
    }
}
