using Resort_Rental.Repository.RepositoryBase;
using ResortRental.Domain.Entity;
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

        public UserService(IBaseRepository<User, long> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _repository.GetAll();
            return users;
        }
        public async Task<User?> GetUser(long userId)
        {
            var user = await _repository.FindById(userId);
            return user;
        }

        public async Task Create(User user)
        {
            await _repository.InsertAsnyc(user);
        }

        public async Task Update(User user)
        {
            await _repository.UpdateAsnyc(user);
        }

        public async Task Delete(User user)
        {
            await _repository.DeleteAsnyc(user);
        }
    }
}
