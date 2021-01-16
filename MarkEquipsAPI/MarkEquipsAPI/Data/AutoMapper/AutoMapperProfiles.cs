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
            CreateMap<ReserverSchedule, ReserverScheduleDto>().ReverseMap();


            CreateMap<Reserver, ReserverDto>().ForMember(dest => dest.Schedules, opt => {
                opt.MapFrom(src => src.ReserverSchedules.Select(x => x.Schedule).ToList());
            }).ReverseMap();
         
            

 

        }
    }
}
