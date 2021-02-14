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
        Task CreateAsync(Reserver reserver);
        Task StatusReserverAsync(Reserver reserver);
        Task DeleteAsync(Reserver reserver);
        Task<bool> IsValidationAsync(int equipId, int schedId, DateTime date, ReserveStatus status);
        Task<List<Reserver>> FindWithPagedSearch(string nameCollaborator, string nameEquipment, int size, int offset, DateTime? date, int status);
        Task<List<Reserver>> FindWithPagedSearchForUser(int id, string nameEquipment, int size, int offset, DateTime? date, int status);
        int GetCountResUser(int id, string FullNameEquipment, DateTime? date, int status);
        int GetCount(string nameCollaborator, string FullNameEquipment, DateTime? date, int status);
    }
}
