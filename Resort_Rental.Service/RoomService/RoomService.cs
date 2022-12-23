using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly IBaseRepository<Room, long> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public RoomService(IBaseRepository<Room, long> repository, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            var rooms = _repository.GetAll();

            var result = rooms.Where(r => r.IsDelete == 0).ToList();

            var roomsDto = _mapper.Map<IEnumerable<RoomDto>>(result);

            return roomsDto;
        }
        public async Task<RoomDto?> GetRoom(long roomId)
        {
            var room = await _repository.FindById(roomId);

            var roomDto = _mapper.Map<RoomDto>(room);

            return roomDto;
        }

        public async Task Create(RoomDto roomDto, IFormFile file)
        {
            var room = _mapper.Map<Room>(roomDto);

            var roomNumber_exists = await _repository.IsExist(r => r.RoomNumber.Contains(room.RoomNumber) || r.RoomNumber == room.RoomNumber);

            if (roomNumber_exists) throw new Exception("Room number already exists");

            var username = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var special = Guid.NewGuid().ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Images\room", special + "-" + file.FileName);
            using (FileStream ms = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(ms);
            }

            if (_httpContext.HttpContext != null)
            {
                room.CreatedByUser = username;
                room.CreationTime = DateTime.Now;
                room.AcctualFileUrl = $"{special}-{file.FileName}";
                room.Status = 0;
                room.IsDelete = 0;
            }

            await _repository.InsertAsnyc(room);
        }

        public async Task Update(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);

            var username = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (_httpContext.HttpContext != null)
            {
                room.UpdatedByUser = username;
                room.LastUpdateTime= DateTime.Now;
            }

            await _repository.UpdateAsnyc(room);
        }

        public async Task Delete(long roomId)
        {
            var roomExists = await _repository.FindById(roomId);

            if (_httpContext.HttpContext != null && roomExists != null)
            {
                var roomDto = _mapper.Map<RoomDto>(roomExists);
                await Update(roomDto);
                roomExists.IsDelete = 1;
                await _repository.DeleteAsnyc(roomExists);
            }
        }
    }
}
