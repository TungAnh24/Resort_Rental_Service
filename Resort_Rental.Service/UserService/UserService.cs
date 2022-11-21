using AutoMapper;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using ResortRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User, long> _repository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User, long> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _repository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDto;
        }
        public async Task<UserDTO?> GetUser(long userId)
        {
            var user = await _repository.FindById(userId);
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task Create(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var userName_exists = _repository.GetAll().Result.All<User>(u => u.Username.Contains(userDTO.Username) || u.Username == userDTO.Username);
            if (!userName_exists)
            {
                throw new Exception("User name already exists");
            }
            else
            {
                await _repository.InsertAsnyc(user);
            }
        }

        public async Task Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _repository.UpdateAsnyc(user);
        }

        public async Task Delete(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _repository.DeleteAsnyc(user);
        }
    }
}
