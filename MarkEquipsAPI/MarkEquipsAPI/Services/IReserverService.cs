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
        Task RevokeAsync(int id);
        Task AddReserverAsync(Reserver reserver);
        Task<Reserver> FindByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
