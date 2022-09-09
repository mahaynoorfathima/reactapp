using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIDEAPI.Model;
using RIDEAPI.Services;

namespace RIDEAPI.Controllers
{
   
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly RideServices _rideservices;
        public FeedbackController(RideServices rideServices)
        {
            this._rideservices = rideServices;
        }

        [HttpGet]
        [Route("api/v1.0/rideapp/feedback/all")]
        public async Task<List<Feedback>> Get()
        {
            return await _rideservices.GettheFeedback();
        }
       


        [HttpPost]
        [Route("/api/v1.0/rideapp/<username>/feedback/<id>")]
        public async Task<OkObjectResult> Insert(Feedback feedback)
        {
            await _rideservices.InsertFeedbackDetails(feedback);
            return Ok(feedback);
        }
        [HttpPut]
        [Route("/api/v1.0/rideapp/<username>/updateFeedback/<id>")]
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
        [Route("/api/v1.0/rideapp/<username>/deleteFeedback/<id>")]
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
