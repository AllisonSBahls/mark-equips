using MarkEquipsAPI.Models;
using System.Collections.Generic;

namespace MarkEquipsAPI.Services
{
    public interface IReserverService
    {
        Reserver Create(Reserver reserver);
        Reserver FindByID(int id);
        List<Reserver> FindAll();
        Reserver Update(Reserver reserver);
        void Delete(int id);
    }
}
