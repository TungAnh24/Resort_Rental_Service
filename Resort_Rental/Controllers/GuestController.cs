using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
