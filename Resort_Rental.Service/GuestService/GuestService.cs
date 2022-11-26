using AutoMapper;
using Microsoft.AspNetCore.Http;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resort_Rental.Repository.DataContext;

namespace Resort_Rental.Service.GuestService
{
    public class GuestService : IGuestService
    {
        private readonly IBaseRepository<Guest, long> _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ApplicationDbContext _context;

        public GuestService(IBaseRepository<Guest, long> repository, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IHttpContextAccessor httpContext, ApplicationDbContext context)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _httpContext = httpContext;
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetGuests()
        {

            var guests = await _userManager.Users.Where(x => x.IsDelete == 0).ToListAsync();

            var result = await (from user in _context.Users
                                join userRole in _context.UserRoles
                                on user.Id equals userRole.UserId
                                join role in _context.Roles
                                on user.Id equals role.Id
                                where user.IsDelete == 0
                                where role.Name == "Customer"
                                select user).ToListAsync();

            var guestDtos = _mapper.Map<IEnumerable<UserDto>>(result);

            return guestDtos;
        }

        public async Task<UserDto> GetGuest(long guestId)
        {
            var guest = await _userManager.FindByIdAsync($"{guestId}");

            var guestDto = _mapper.Map<UserDto>(guest);

            return guestDto;
        }

        public async Task Create(UserDto guestDto)
        {

            var guest = _mapper.Map<AppUser>(guestDto);

            var guestExists = await _userManager.FindByNameAsync(guest.Email);

            if (guestExists != null) throw new Exception("Guest name is already exists");
            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (_httpContext.HttpContext != null)
            {
                guest.CreatedByUser = creator;
                guest.CreationTime = DateTime.Now;
                guest.IsDelete = 0;
            }

            await _userManager.CreateAsync(guest, guest.PasswordHash);
        }

        public async Task Update(UserDto guestDto)
        {
            var guest = _mapper.Map<AppUser>(guestDto);

            var updater = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (_httpContext.HttpContext != null)
            {
                guest.UpdatedByUser = updater;
                guest.LastUpdateTime = DateTime.Now;
            }

            await _userManager.UpdateAsync(guest);
        }

        public async Task Delete(long guestId)
        {
            var guestExists = await _userManager.FindByIdAsync($"{guestId}");

            if (guestExists != null)
            {
                var guestDto = _mapper.Map<UserDto>(guestExists);
                await Update(guestDto);
                guestExists.IsDelete = 1;
                await _userManager.DeleteAsync(guestExists);
            }
        }
        
    }
}
