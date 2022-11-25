using AutoMapper;
using Microsoft.AspNetCore.Http;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<AppUser, long> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IBaseRepository<AppUser, long> repository, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _repository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }
        public async Task<UserDto?> GetUser(long userId)
        {
            var user = await _repository.FindById(userId);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task Create(UserDto userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);

            var userName_exists = await _repository.IsExist(u => u.UserName== user.UserName || u.UserName.Contains(user.UserName));
            if (userName_exists) throw new Exception("User name already exists");

            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (_httpContext.HttpContext != null)
            {
                user.CreatedByUser = creator;
                user.CreationTime= DateTime.Now;
                user.IsDelete = 0;
            }

            await _repository.InsertAsnyc(user);
        }

        public async Task Update(UserDto userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);

            var updater = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (_httpContext.HttpContext != null)
            {
                user.UpdatedByUser = updater;
                user.LastUpdateTime = DateTime.Now;
            }

            await _repository.UpdateAsnyc(user);
        }

        public async Task Delete(long userId)
        {
            var userExists = await _repository.FindById(userId);

            if (userExists != null)
            {
                var userDto = _mapper.Map<UserDto>(userExists);
                await Update(userDto);
                userExists.IsDelete= 1;
                await _repository.DeleteAsnyc(userExists);
            }
        }
    }
}
