using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIDEAPI.Model;
using RIDEAPI.Services;

namespace RIDEAPI.Controllers
{
    [Route("api/v1.0/rideapp/<username>/[controller]")]
    [ApiController]
    public class bookrideController : ControllerBase
    {
        private readonly RideServices _rideservices;
        public bookrideController(RideServices rideServices)
        {
            this._rideservices = rideServices;
        }

        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await _rideservices.GettheBook();
        }

        

        [HttpPost]
        public async Task<OkObjectResult> Insert(Book book)
        {
            await _rideservices.InsertBookDetails(book);
            return Ok(book);
        }
    }
}
