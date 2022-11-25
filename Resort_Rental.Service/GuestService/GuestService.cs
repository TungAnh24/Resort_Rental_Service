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

namespace Resort_Rental.Service.GuestService
{
    public class GuestService : IGuestService
    {
        private readonly IBaseRepository<Guest, long> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public GuestService(IBaseRepository<Guest, long> repository, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<GuestDto>> GetGuests()
        {
            var guests = await _repository.GetAll();
            var guestDtos = _mapper.Map<IEnumerable<GuestDto>>(guests);
            return guestDtos;
        }

        public async Task<GuestDto> GetGuest(long guestId)
        {
            var guest = await _repository.FindById(guestId);
            var guestDto = _mapper.Map<GuestDto>(guest);
            return guestDto;
        }

        public async Task Create(GuestDto guestDto)
        {

            var guest = _mapper.Map<Guest>(guestDto);

            var guestExists = await _repository.IsExist(g => g.Fullname.Contains(guest.Fullname) || g.Fullname == guest.Fullname);

            if (guestExists) throw new Exception("Guest name is already exists");
            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (_httpContext.HttpContext != null) 
            {
                guest.CreatedByUser = creator;
                guest.CreationTime = DateTime.Now;
                guest.Status = 0;
                guest.IsDelete = 0;
            }
            await _repository.InsertAsnyc(guest);
        }

        public async Task Update(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);

            var updater = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (_httpContext.HttpContext != null)
            {
                guest.UpdatedByUser = updater;
                guest.LastUpdateTime = DateTime.Now;
            }

            await _repository.UpdateAsnyc(guest);
        }

        public async Task Delete(long guestId)
        {
            var guestExists = await _repository.FindById(guestId);
            if (guestExists != null)
            {
                var guestDto = _mapper.Map<GuestDto>(guestExists);
                await Update(guestDto);
                guestExists.IsDelete = 1;
                await _repository.DeleteAsnyc(guestExists);
            }
        }
        
    }
}
