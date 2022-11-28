using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using Resort_Rental.Repository.DataContext;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Service.GuestService;
using Resort_Rental.Service.RoomService;
using Resort_Rental.Service.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.ContractService
{
    public class ContractService : IContractService
    {
        private readonly IBaseRepository<Contract, long> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IBaseRepository<Room, long> _repositoryRoom;
        private readonly IBaseRepository<AppUser, long> _repositoryUser;
        private readonly ApplicationDbContext _context;

        public ContractService(IBaseRepository<Contract, long> repository, IMapper mapper, IHttpContextAccessor httpContext, IBaseRepository<Room, long> repositoryRoom, IBaseRepository<AppUser, long> repositoryUser, ApplicationDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContext;
            _repositoryRoom = repositoryRoom;
            _repositoryUser = repositoryUser;
            _context = context;
        }

        public async Task<IEnumerable<ContractDto>> GetAllAsync()
        {
            var a = await _context.Contracts.Include(x => x.Room).SingleOrDefaultAsync();

            var listContracts = _repository.GetAll().Include(x => x.Room).Include(x => x.User);

            var result = listContracts.Where(x => x.IsDelete == 0).ToList();

            var listContractsDto = _mapper.Map<IEnumerable<ContractDto>>(result);

            return listContractsDto;
        }

        public async Task<ContractDto> GetContractAsync(long contractid)
        {
            var a = await _context.Contracts.Include(x => x.Room).SingleOrDefaultAsync(x => x.Id == contractid);
            var contract = await _repository.FindById(contractid);
            var contractDto = _mapper.Map<ContractDto>(contract);
            return contractDto;
        }

        public async Task CreateAsync(ContractDto contractDto)
        {
            var contract = _mapper.Map<Contract>(contractDto);

            var contractNumber_exists = _repository.IsExist(x => x.ContractNumber.Contains(contract.ContractNumber) || x.ContractNumber == contract.ContractNumber);

            /*if (contractNumber_exists != null) throw new Exception("Contract number is alread exists.");*/

            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            /*var createRoom = _roomService.GetRoom();*/
            var room = await _repositoryRoom.FindById(contractDto.roomId);
            var user = await _repositoryUser.FindById(contractDto.userId);
            contract.Room = room;
            contract.User = user;

            if (_httpContext.HttpContext != null)
            {
                contract.CreationTime = DateTime.Now;
                contract.CreatedByUser = creator;
                contract.IsDelete = 0;
            }

            await _repository.InsertAsnyc(contract);
        }

        public async Task UpdateAsync(ContractDto contractDto)
        {
            var contract = _mapper.Map<Contract>(contractDto);

            var updater = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            if (_httpContext.HttpContext != null)
            {
                contract.LastUpdateTime = DateTime.Now;
                contract.UpdatedByUser = updater;
            }

            await _repository.UpdateAsnyc(contract);
        }

        public async Task DeleteAsync(long contractId)
        {
            var contractExists = await _repository.FindById(contractId);

            if (contractExists != null)
            {
                var contractDto = _mapper.Map<ContractDto>(contractExists);
                await UpdateAsync(contractDto);
                contractExists.IsDelete = 1;
                await _repository.DeleteAsnyc(contractExists);
            }
        }
    }
}
