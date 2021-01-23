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
        Task RevokeAsync(Reserver reserver);
        Task DeleteAsync(Reserver reserver);
        Task<bool> IsValidationAsync(int equipId, int schedId, DateTime date, ReserveStatus status);
        Task<List<Reserver>> FindWithPagedSearch(string nameCollaborator, string nameEquipment, int size, int offset);
        Task<List<Reserver>> FindWithPagedSearchForUser(int id, string nameEquipment, int size, int offset);
        int GetCountResUser(int id, string FullNameEquipment);
        int GetCount(string nameCollaborator, string nameEquipment);
    }
}
