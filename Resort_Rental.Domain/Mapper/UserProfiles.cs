using AutoMapper;
using Resort_Rental.Domain.Dto;
using ResortRental.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Mapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles() { CreateMap<User, UserDTO>(); }
    }
}
