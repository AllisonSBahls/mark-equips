using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEquipmentService
    {
        private readonly IRepository<Equipment> _repository;

        public EquipmentServiceImplementation(IRepository<Equipment> repository)
        {
            _repository = repository;
        }

        public async Task<List<Equipment>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Equipment> FindByIDAsync(int id)
        {
            return await _repository.FindByIDAsync(id);
        }

        public async Task<Equipment> CreateAsync(Equipment equipment)
        {
            return await _repository.CreateAsync(equipment);
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            var result = await _repository.FindByIDAsync(equipment.Id);
            if (result != null)
            {
                await _repository.UpdateAsync(result, equipment);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _repository.FindByIDAsync(id);
            if (result != null)
            {
                await _repository.DeleteAsync(result);
            }
        }

    }
}
