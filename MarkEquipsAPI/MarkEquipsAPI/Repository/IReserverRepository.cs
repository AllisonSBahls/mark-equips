﻿using MarkEquipsAPI.Models;
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
        int GetCount(string nameCollaborator, string nameEquipment);
    }
}
