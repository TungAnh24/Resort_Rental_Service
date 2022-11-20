using AutoMapper;
using Resort_Rental.Domain.Dto;
using Resort_Rental.Repository.RepositoryBase;
using ResortRental.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly IBaseRepository<Room, long> _repository;
        private readonly IMapper _mapper;

        public RoomService(IBaseRepository<Room, long> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            var rooms = await _repository.GetAll();
            var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);
            return roomsDto;
        }
        public async Task<RoomDto?> GetRoom(long roomId)
        {
            var room = await _repository.FindById(roomId);
            var roomDto = _mapper.Map<RoomDto>(room);
            return roomDto;
        }

        public async Task Create(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            var roomNumber_exists = _repository.GetAll().Result.ToList()
                .Where(r => r.RoomNumber.Contains(room.RoomNumber) || r.RoomNumber == room.RoomNumber)
                .FirstOrDefault();
            if (roomNumber_exists != null)
            {
                throw new Exception("Room number already exists");
            }
            else
            {
                await _repository.InsertAsnyc(room);
            }
        }

        public async Task Update(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _repository.UpdateAsnyc(room);
        }

        public async Task Delete(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _repository.DeleteAsnyc(room);
        }
    }
}
