using ResortRental.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(long userId);
        Task Create(User room);
        Task Update(User room);
        Task Delete(User room);
    }
}
