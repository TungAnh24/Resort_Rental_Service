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
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Email, conf => conf.MapFrom(u => u.Email))
                .ForMember(dest => dest.Password, conf => conf.MapFrom(u => u.PasswordHash));
            CreateMap<UserDto, AppUser>();
        }
    }
}
