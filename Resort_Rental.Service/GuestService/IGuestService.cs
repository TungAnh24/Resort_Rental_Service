using Resort_Rental.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.GuestService
{
    public interface IGuestService
    {
        Task<IEnumerable<UserDto>> GetGuests();
        Task<UserDto> GetGuest(long guestId);
        Task Create(UserDto guestDto);
        Task Update(UserDto guestDto);
        Task Delete(long guestId);
    }
}
