using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(long userId);
        Task Create(UserDto user);
        Task Update(UserDto userDto);
        Task Delete(long userId);
    }
}
