using Microsoft.AspNetCore.Http;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
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
        Task Create(RoomDto roomDto, IFormFile file);
        Task Update(RoomDto roomDto);
        Task Delete(long roomId);
    }
}
