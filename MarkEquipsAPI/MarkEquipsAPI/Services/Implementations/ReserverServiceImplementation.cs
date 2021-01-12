using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class ReserverServiceImplementation : IReserverService
    {
        private readonly IReserverRepository _repository;

        public ReserverServiceImplementation(IReserverRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Reserver>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }
    }
}
    

