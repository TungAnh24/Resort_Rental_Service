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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Resort_Rental.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userManager.Users.Include(x => x.AppRole).Where(x => x.IsDelete == 0).ToListAsync();

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }
        public async Task<UserDto> GetUser(long userId)
        {
            var user = await _userManager.FindByIdAsync($"{userId}");

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task Create(UserDto userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);

            var userName_exists = await _userManager.FindByNameAsync(user.UserName);

            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (userName_exists != null) throw new Exception("User name already exists");

            var role = await _roleManager.FindByIdAsync($"{userDTO.roleId}");
            if (_httpContext.HttpContext != null)
            {
                user.CreatedByUser = creator;
                user.CreationTime= DateTime.Now;
                user.AppRole = role;
                user.IsDelete = 0;
            }

            await _userManager.CreateAsync(user);
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

            await _userManager.UpdateAsync(user);
        }

        public async Task Delete(long userId)
        {
            var userExists = await _userManager.FindByIdAsync($"{userId}");

            if (userExists != null)
            {
                var userDto = _mapper.Map<UserDto>(userExists);
                await Update(userDto);
                userExists.IsDelete= 1;
                await _userManager.DeleteAsync(userExists);
            }
        }
    }
}
