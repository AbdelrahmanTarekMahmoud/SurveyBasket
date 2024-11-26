﻿
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            var polls = _pollService.GetAll();
            var response = polls.Adapt<IEnumerable<PollResponse>>();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var poll = _pollService.Get(id);
            if(poll == null)
            {
                return NotFound();
            }
            var response = poll.Adapt<PollResponse>();
            return Ok(response);
        }
        [HttpPost("")]
        public IActionResult Add([FromBody]PollRequest request)
        {
            var newPoll = _pollService.Add(request.Adapt<Poll>());
            return CreatedAtAction(nameof(Get) , new {id = newPoll.Id } , newPoll);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id , [FromBody] PollRequest request)
        {
            var isUpdated  = _pollService.Update(id , request.Adapt<Poll>());
            if (!isUpdated) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id )
        {
            var isExisted = _pollService.Delete(id);
            if(!isExisted) return NotFound();
            return NoContent();
        }
        
    }
}
