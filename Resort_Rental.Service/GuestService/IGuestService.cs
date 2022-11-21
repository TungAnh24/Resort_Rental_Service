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
        Task<IEnumerable<GuestDto>> GetGuests();
        Task<GuestDto> GetGuest(long guestId);
        Task Create(GuestDto guestDto);
        Task Update(GuestDto guestDto);
        Task Delete(GuestDto guestDto);
    }
}
