using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using Resort_Rental.Service.GuestService;

namespace Resort_Rental.Controllers
{
    [Route("resort_manager/customer")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _guestService.GetGuests();
            return customers == null ? BadRequest() : Ok(customers);
        }

        [HttpGet]
        [Route("get-customer/{customerId}")]
        public async Task<IActionResult> GetCustomerById(long customerId)
        {
            var customer = await _guestService.GetGuest(customerId);
            return customer == null ? NoContent() : Ok(customer);
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            await _guestService.Create(userDto);
            return Ok("Create a successful customer.");
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _guestService.Update(userDto);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{customerId}")]
        public async Task<IActionResult> Delete(long customerId)
        {
            var customer = await _guestService.GetGuest(customerId);
            if (customer == null)
                return NotFound($"Customer name: {customer?.Username} not found!");
            else
            {
                await _guestService.Delete(customerId);
                return Ok($"Successfully deleted customer name: {customer.Username}.");
            }
        }

        [HttpGet]
        [Route("get-role")]
        public async Task<IActionResult> GetRole(string roleName)
        {
            var customers = await _guestService.GetRoleByName(roleName);
            return customers == null ? BadRequest() : Ok(customers);
        }
    }
}
