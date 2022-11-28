using AutoMapper;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Mapper
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<Contract, ContractDto>()
                .ForMember(dest => dest.Id, conf => conf.MapFrom(x => x.Id))
                .ForMember(dest => dest.ContractNumber, conf => conf.MapFrom(x => x.ContractNumber))
                .ForMember(dest => dest.Price, conf => conf.MapFrom(x => x.Price))
                .ForMember(dest => dest.FileLocation, conf => conf.MapFrom(x => x.FileLocation))
                .ForPath(dest => dest.RoomNumber, conf => conf.MapFrom(x => x.Room.RoomNumber))
                .ForPath(dest => dest.UserName, conf => conf.MapFrom(x => x.User.UserName));
            CreateMap<ContractDto, Contract>()
                .ForMember(dest => dest.Id, conf => conf.MapFrom(x => x.Id))
                .ForMember(dest => dest.ContractNumber, conf => conf.MapFrom(x => x.ContractNumber))
                .ForMember(dest => dest.Price, conf => conf.MapFrom(x => x.Price))
                .ForMember(dest => dest.FileLocation, conf => conf.MapFrom(x => x.FileLocation));
        }
    }
}
