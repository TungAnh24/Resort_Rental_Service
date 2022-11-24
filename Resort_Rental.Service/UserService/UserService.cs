using AutoMapper;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Repository.RepositoryBase;
using ResortRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<AppUser, long> _repository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<AppUser, long> repository, IMapper mapper)
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
            var user = _mapper.Map<AppUser>(userDTO);
            var userName_exists = await _repository.IsExist(u => u.UserName== user.UserName || u.UserName.Contains(user.UserName));
            if (userName_exists) throw new Exception("User name already exists");
            await _repository.InsertAsnyc(user);
            
        }

        public async Task Update(UserDTO userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);
            await _repository.UpdateAsnyc(user);
        }

        public async Task Delete(UserDTO userDTO)
        {
            var user = _mapper.Map<AppUser>(userDTO);
            await _repository.DeleteAsnyc(user);
        }

        /*public Task<bool> IsExist(Expression<Func<UserDTO, bool>> predicate)
        {
            predicate = u => u.Username.Contains()
        }*/
    }
}
