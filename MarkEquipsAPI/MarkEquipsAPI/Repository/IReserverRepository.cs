using MarkEquipsAPI.Models;
using MarkEquipsAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository
{
    public interface IReserverRepository
    {
        Task<List<Reserver>> FindAllAsync();
        Task<Reserver> FindByIdAsync(int id);
        Task AddReserverAsync(Reserver reserver);
        Task RevokeReserverAsync(Reserver reserver);
        Task DeleteAsync(Reserver reserver);

        Task<bool> IsValidationAsync(int equipId, int schedId, DateTime date, ReserveStatus status);
        Task<int> CountEquipmentReserverAsync(int equipId);


    }
}
