using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Service.ContractService
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDto>> GetAllAsync();
        Task<ContractDto> GetContractAsync(long contractid);
        Task CreateAsync(ContractDto contractDto);
        Task UpdateAsync(ContractDto contractDto);
        Task DeleteAsync(long contractId);
    }
}
