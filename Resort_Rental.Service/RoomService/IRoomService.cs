using Resort_Rental.Domain.Dtos;
using ResortRental.Domain.Entities;
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
