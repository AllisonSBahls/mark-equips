using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public interface IReserverRepository
    {
        Task<List<Reserver>> FindAllAsync();

        Task<Reserver> AddReserverAsync(Reserver reserver);
        bool IsValidation(int equipId, int schedId, DateTime date);

    }
}
