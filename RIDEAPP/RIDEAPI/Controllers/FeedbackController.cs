using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIDEAPI.Model;
using RIDEAPI.Services;

namespace RIDEAPI.Controllers
{
    [Route("api/v1.0/ rideapp /feedback/all")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly RideServices _rideservices;
        public FeedbackController(RideServices rideServices)
        {
            this._rideservices = rideServices;
        }

        [HttpGet("GetById1")]
        public async Task<ActionResult<Feedback>> GetbyId(string id)
        {
            var feedback = await _rideservices.GetById1(id);
            if (feedback is null)
                return NotFound();

            return feedback;
        }


        [HttpPost]
        public async Task<OkObjectResult> Insert(Feedback feedback)
        {
            await _rideservices.InsertFeedbackDetails(feedback);
            return Ok(feedback);
        }
        [HttpPut]
        public async Task<IActionResult> Update(string id, Feedback feedback)
        {
            var existingitem = await _rideservices.GetById1(id);

            if (existingitem is null)
            {
                return NotFound();
            }
            feedback.Id = existingitem.Id;
            await _rideservices.UpdateFeedbackDetails(id, feedback);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var existingitem = await _rideservices.GetById1(id);

            if (existingitem is null)
            {
                return NotFound();
            }
            await _rideservices.DeleteFeedbackDetails(id);
            return NoContent();
        }

    }
    
}
