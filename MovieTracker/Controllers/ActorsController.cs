using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models.Dto;
using MovieTracker.Models.Entities;
using MovieTracker.Services;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _actorsService;
        private readonly IMapper _mapper;

        public ActorsController
            (IActorsService actorsService,
            IMapper mapper)
        {
            _actorsService = actorsService;
            _mapper = mapper;
        }

        [HttpPost("createActor")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ActorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActorResponse>> CreateActor(
            ActorRequest actorRequest)
        {
            var actor = _mapper.Map<Actor>(actorRequest);
            var outActor = await _actorsService.CreateAsync(actor);

            return CreatedAtAction(
                nameof(GetActorById),
                new {actorId = outActor.Id },
                _mapper.Map<ActorResponse>(outActor));
        }
        [HttpGet("getAllActors")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse[]))]
        public async Task<ActionResult<IEnumerable<ActorResponse>>> GetAllActors()
        {
            var actors = await _actorsService.GetAllAsync();
            return _mapper.Map<ActorResponse[]>(actors);
        }


        [HttpGet("getActorById/{actorId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse))]
        public async Task<ActionResult<ActorResponse>> GetActorById(
            int actorId)
        {
            var actor = await _actorsService.GetAsync(actorId);

            return _mapper.Map<ActorResponse>(actor);

        }

        [HttpPut("updateActor/{actorId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ActorResponse>> UpdateActor(
            int actorId,
            ActorRequest actorRequest)
        {
            var actor = await _actorsService.GetAsync(actorId);
            if(actor == null)
            {
                return NotFound();
            }

            _mapper.Map(actorRequest, actor);

            Actor updatedActor = await _actorsService.UpdateAsync(actorId, actor);

            return Ok(_mapper.Map<ActorResponse>(updatedActor));
        }

        [HttpDelete("deleteActor/{actorId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ActorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteMovie(int actorId)
        {
            var actor = await _actorsService.DeleteAsync(actorId);

            if (actor == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
