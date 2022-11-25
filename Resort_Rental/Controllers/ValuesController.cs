using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resort_Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("api/Tokens")]
        public IActionResult TestAuthorization()
        {
            return Ok("You're Authorized");
        }
    }
}
