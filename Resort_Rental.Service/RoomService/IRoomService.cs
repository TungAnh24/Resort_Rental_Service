using Resort_Rental.Domain.Dto;
using ResortRental.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.RoomService
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetRooms();
        Task<RoomDto?> GetRoom(long roomId);
        Task Create(RoomDto roomDto);
        Task Update(RoomDto roomDto);
        Task Delete(RoomDto roomDto);
    }
}
