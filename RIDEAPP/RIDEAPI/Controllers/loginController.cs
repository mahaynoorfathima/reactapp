using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIDEAPI.Model;
using RIDEAPI.Services;

namespace RIDEAPI.Controllers
{
    [Route("api/v1.0/ rideapp/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly RideServices _rideservices;
        public loginController(RideServices rideServices)
        {
            this._rideservices = rideServices;
        }

        [HttpGet]
        public async Task<List<Login>> Get()
        {
            return await _rideservices.GettheLogin();
        }
    }
}
