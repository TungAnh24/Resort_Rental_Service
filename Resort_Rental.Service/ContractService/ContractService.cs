using AutoMapper;
using Microsoft.AspNetCore.Http;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Service.GuestService;
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
        private readonly IGuestService _guestService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;

        public ContractService(IBaseRepository<Contract, long> repository, IMapper mapper, IGuestService guestService, IUserService userService, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _mapper = mapper;
            _guestService = guestService;
            _userService = userService;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<ContractDto>> GetAllAsync()
        {
            var listContracts = await _repository.GetAll();

            var result = listContracts.Where(x => x.IsDelete == 0).ToList();

            var listContractsDto = _mapper.Map<IEnumerable<ContractDto>>(result);

            return listContractsDto;
        }

        public async Task<ContractDto> GetContractAsync(long contractid)
        {
            var contract = await _repository.FindById(contractid);
            var contractDto = _mapper.Map<ContractDto>(contract);
            return contractDto;
        }

        public async Task CreateAsync(ContractDto contractDto)
        {
            var contract = _mapper.Map<Contract>(contractDto);

            var contractNumber_exists = _repository.IsExist(x => x.ContractNumber.Contains(contract.ContractNumber) || x.ContractNumber == contract.ContractNumber);

            if (contractNumber_exists != null) throw new Exception("Contract number is alread exists.");

            var creator = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);

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
