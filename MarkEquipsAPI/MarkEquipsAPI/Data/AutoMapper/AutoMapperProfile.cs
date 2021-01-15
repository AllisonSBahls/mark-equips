using AutoMapper;
using MarkEquipsAPI.Data.DTO;
using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Data.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Reserver, ReserverDto>()
              .ForMember(dest => dest.Schedules, opt => {
                  opt.MapFrom(src => src.ReserverSchedules.Select(x => x.Schedule).ToList());
              }).ReverseMap();


            CreateMap<Schedule, ScheduleDto>().ForMember(dest => dest.Reserves, opt =>{
                opt.MapFrom(src => src.ReserverSchedules.Select(x => x.Reserver).ToList());
            }).ReverseMap();

         
            CreateMap<Equipment, EquipmentDto>().ReverseMap();

            CreateMap<Collaborator, CollaboratorDto>().ReverseMap();

 

        }
    }
}
