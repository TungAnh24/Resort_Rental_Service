using AutoMapper;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Mapper
{
    public class RoomProfiles : Profile
    {
        public RoomProfiles() {
            /*CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.Id, conf => conf.MapFrom(room => room.Id))
                .ForMember(dest => dest.RoomNumber, conf => conf.MapFrom(room => room.RoomNumber))
                .ForMember(dest => dest.Price, conf => conf.MapFrom(room => room.Price))
                .ForMember(dest => dest.Square, conf => conf.MapFrom(room => room.Square))
                .ForMember(dest => dest.Description, conf => conf.MapFrom(room => room.Description))
                .ForMember(dest => dest.ElectricCounter, conf => conf.MapFrom(room => room.ElectricCounter))
                .ForMember(dest => dest.WaterCounter, conf => conf.MapFrom(room => room.WaterCounter))
                .ForMember(dest => dest.Status, conf => conf.MapFrom(room => room.Status))
                .ForMember(dest => dest.CreationTime, conf => conf.MapFrom(room => room.CreationTime))
                .ForMember(dest => dest.LastUpdateTime, conf => conf.MapFrom(room => room.LastUpdateTime))
                .ForMember(dest => dest.CreatedByUser, conf => conf.MapFrom(room => room.CreatedByUser))
                .ForMember(dest => dest.UpdatedByUser, conf => conf.MapFrom(room => room.UpdatedByUser));*/
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();
        }
    }
}
