﻿using AutoMapper;
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
            var roomNumber_exists = await _repository.IsExist(r => r.RoomNumber.Contains(room.RoomNumber) || r.RoomNumber == room.RoomNumber);
            if (roomNumber_exists) throw new Exception("Room number already exists");
            var username = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (_httpContext.HttpContext != null)
            {
                room.CreatedByUser = username;
                room.CreationTime = DateTime.Now;
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
            var username = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (_httpContext.HttpContext != null && roomExists != null)
            {
                roomExists.UpdatedByUser = username;
                roomExists.LastUpdateTime = DateTime.Now;
                roomExists.IsDelete = 1;
                await _repository.DeleteAsnyc(roomExists);
            }
        }
    }
}
