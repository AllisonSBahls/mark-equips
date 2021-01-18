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

            CreateMap<Reserver, ReserverDto>()
                .ForMember(dest => dest.Collaborator, opt => opt.MapFrom(src => src.Collaborator.Name))
                .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule))
                .ForMember(dest => dest.Equipment, opt => opt.MapFrom(src => src.Equipment.Name))
                .ForMember(dest => dest.NumberEquip, opt => opt.MapFrom(src => src.Equipment.Number));
       
                
            CreateMap<ReserverDto, Reserver>();

        }
    }
}
