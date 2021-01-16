using AutoMapper;
using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Data.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Equipment, EquipmentDto>().ReverseMap();

            CreateMap<Collaborator, CollaboratorDto>().ReverseMap();

            CreateMap<Schedule, ScheduleDto>().ReverseMap();

            CreateMap<Reserver, ReserverDto>().ReverseMap();
         
            

 

        }
    }
}
