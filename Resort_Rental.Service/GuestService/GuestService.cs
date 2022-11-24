using AutoMapper;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using ResortRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.GuestService
{
    public class GuestService : IGuestService
    {
        private readonly IBaseRepository<Guest, long> _repository;
        private readonly IMapper _mapper;

        public GuestService(IBaseRepository<Guest, long> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            if (guestExists)
            {
                await _repository.InsertAsnyc(guest);
            } else {
                throw new Exception("Guest name is already exists");
            }
        }

        public async Task Update(GuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            await _repository.UpdateAsnyc(guest);
        }

        public async Task Delete(long guestId)
        {
            var guestExists = await _repository.FindById(guestId);
            if (guestExists != null)
            {
                guestExists.IsDelete = 1;
                await _repository.DeleteAsnyc(guestExists);
            }
        }
        
    }
}
