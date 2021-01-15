using AutoMapper;
using MarkEquipsAPI.Data.DTO;
using MarkEquipsAPI.Models;
using MarkEquipsAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEquipmentService
    {
        private readonly IRepository<Equipment> _repository;
        private readonly IMapper _mapper;


        public EquipmentServiceImplementation(IRepository<Equipment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EquipmentDto>> FindAllAsync()
        {
            var equipment = await _repository.FindAllAsync();
            return _mapper.Map<List<EquipmentDto>>(equipment);
        }

        public async Task<EquipmentDto> FindByIDAsync(int id)
        {
            var equipment = await _repository.FindByIDAsync(id);
            return _mapper.Map<EquipmentDto>(equipment);
        }

        public async Task<EquipmentDto> CreateAsync(EquipmentDto equipment)
        {
            var result = _mapper.Map<Equipment>(equipment);
            result = await _repository.CreateAsync(result);
            return _mapper.Map<EquipmentDto>(result);
        }

        public async Task UpdateAsync(EquipmentDto equipment)
        {
            var result = _mapper.Map<Equipment>(equipment);
            var find = await _repository.FindByIDAsync(result.Id);
            if (result != null)
            {
                await _repository.UpdateAsync(find, result);
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
