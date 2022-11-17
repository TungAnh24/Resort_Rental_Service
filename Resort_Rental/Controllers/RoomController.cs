using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resort_Rental.Domain.Dto;
using Resort_Rental.Service.RoomService;
using ResortRental.Domain.Entity;

namespace Resort_Rental.Controllers
{
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("resort_manager/rooms")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetRooms();
            return rooms == null ? BadRequest() : Ok(rooms);
        }

        [HttpGet]
        [Route("resort_manager/room/{roomId}")]
        public async Task<IActionResult> GetRooms(long roomId)
        {
            var room = await _roomService.GetRoom(roomId);
            return room == null ? BadRequest() : Ok(room);
        }

        [HttpPost]
        [Route("resort_manager/add_new")]
        public async Task<IActionResult> CreateRoom(RoomDto roomDto)
        {
            await _roomService.Create(roomDto);
            return Ok();
        }

        [HttpPost]
        [Route("resort_manager/update")]
        public async Task<IActionResult> UpdateRoom(RoomDto roomDto)
        {
            await _roomService.Update(roomDto);
            return Ok();
        }

        [HttpDelete]
        [Route("resort_manager/delete/{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            var existRoom = await _roomService.GetRoom(id);
            if (existRoom != null)
            {
                await _roomService.Delete(existRoom);
                return Ok();
            } else
            {
                return NotFound($"Room number: {existRoom?.RoomNumber} not found!");
            }
        }
    }
}
