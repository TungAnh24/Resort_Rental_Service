using Resort_Rental.Domain.Dtos;
using ResortRental.Domain.Entities;
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
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO?> GetUser(long userId);
        Task Create(UserDTO room);
        Task Update(UserDTO room);
        Task Delete(UserDTO room);
    }
}
