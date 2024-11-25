
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase //primary Constructor
    {
        private readonly IPollService _pollService = pollService ;
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_pollService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return _pollService.Get(id) is null ? NotFound() : Ok(_pollService.Get(id));
        }
        [HttpPost("")]
        public IActionResult Add(Poll request)
        {
            var newPoll = _pollService.Add(request);
            return CreatedAtAction(nameof(Get) , new {id = newPoll.Id } , newPoll);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id , Poll request)
        {
            var isUpdated  = _pollService.Update(id , request);
            if (!isUpdated) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            var isExisted = _pollService.Delete(id);
            if(!isExisted) return NotFound();
            return NoContent();
        }
        
    }
}
