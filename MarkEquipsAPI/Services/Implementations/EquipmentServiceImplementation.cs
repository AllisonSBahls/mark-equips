using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Services.Implementations
{
    public class EquipmentServiceImplementation : IEntitieServices
    {
        private volatile int count;

        public Equipment Create(Equipment equip)
        {
            return equip;
        }

        public void Delete(long id)
        {

        }

        public List<Equipment> FindAll()
        {
            List<Equipment> equipments = new List<Equipment>();
            for (int i = 0; i < 8; i++)
            {
                Equipment equipment = MockEquips(i);
                equipments.Add(equipment);
            }
            return equipments;
        }



        public Equipment FindById(long id)
        {
            return new Equipment
            {
                Id = 1,
                Name = "Projeto",
                Description = "Projetor Dell preto",
                Number = 1212
            };
        }

        public Equipment Update(Equipment equip)
        {
            return equip;
        }

        private Equipment MockEquips(int i)
        {
            return new Equipment
            {
                Id = IncrementAndGet(),
                Name = "Equip name" + i,
                Description = "Equip description" + i,
                Number = 1231 + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
