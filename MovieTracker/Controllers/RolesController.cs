using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models.Dto;
using MovieTracker.Models.Entities;
using MovieTracker.Services;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        private readonly IMapper _mapper;

        public RolesController(
            IRolesService rolesService,
            IMapper mapper)
        {
            _rolesService = rolesService;
            _mapper = mapper;
        }

        [HttpGet("getAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResonse[]))]
        public async Task<ActionResult<IEnumerable<RoleResonse>>> GetAllMovies()
        {
            var roles = await _rolesService.GetAllAsync();

            return _mapper.Map<RoleResonse[]>(roles);
        }

        [HttpPost("createRole")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RoleResonse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RoleResonse>> CreateRole(RoleRequst roleRequst)
        {
            var role = _mapper.Map<Role>(roleRequst);

            var outRole = await _rolesService.CreateAsync(role);

            return CreatedAtAction(
                nameof(GetRoleById),
                new { roleid = outRole.Id },
                _mapper.Map<RoleResonse>(outRole));
        }


        [HttpGet("GetRoleById/{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleResonse))]
        public async Task<ActionResult<RoleResonse>> GetRoleById(
           int roleId)
        {
            var role = await _rolesService.GetAsync(roleId);

            return _mapper.Map<RoleResonse>(role);
        }
    }
}
