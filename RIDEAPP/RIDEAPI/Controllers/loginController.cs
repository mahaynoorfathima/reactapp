using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIDEAPI.Model;
using RIDEAPI.Services;

namespace RIDEAPI.Controllers
{
    
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly RideServices _rideservices;
        public loginController(RideServices rideServices)
        {
            this._rideservices = rideServices;
        }

        [HttpGet]
        [Route("api/v1.0/rideapp/[controller]")]
        public async Task<List<Login>> Get()
        {
            return await _rideservices.GettheLogin();
        }

        [HttpGet("/api/v1.0/rideapp/<username>/forgot")]
        public async Task<ActionResult<Login>> GetbyId(string email)
        {
            var login = await _rideservices.GetByEmail(email);
            if (login is null)
                return NotFound();

            return login;
        }

    }
}
