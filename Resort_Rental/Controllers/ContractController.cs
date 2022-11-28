using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Service.ContractService;

namespace Resort_Rental.Controllers
{
    [Route("resort_manager/contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var listContracts = await _contractService.GetAllAsync();
            return Ok(listContracts);
        }

        [HttpGet]
        [Route("get-contract/{contractId}")]
        public async Task<IActionResult> GetById(long contractId )
        {
            var contract = await _contractService.GetContractAsync(contractId);
            return Ok(contract);
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> Create(ContractDto contractDto)
        {
            await _contractService.CreateAsync(contractDto);
            return Ok("Create a successful contract");
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(ContractDto contractDto)
        {
            await _contractService.UpdateAsync(contractDto);
            return Ok("Update a successful contract");
        }
    }
}
