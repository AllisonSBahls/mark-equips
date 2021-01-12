using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services
{
    public interface IReserverService
    {
        Task<List<Reserver>> FindAllAsync();

        Task<Reserver> AddReserverAsync(Reserver reserver);
    }
}
