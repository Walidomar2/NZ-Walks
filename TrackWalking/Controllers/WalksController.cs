using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.CustomActionFilters;
using NZWalks.DTOs.Walk;
using NZWalks.Interfaces;
using NZWalks.Models;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateWalkDTO model)
        {

            var walk = _mapper.Map<Walk>(model);

            walk = await _walkRepository.CreateAsync(walk);

            if (walk == null)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction(nameof(GetById), new {id= walk.Id}, _mapper.Map<WalkDTO>(walk));
        }

        [HttpGet]
        [Authorize] // Reader and Writer can Read data
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,[FromQuery] int pageNumber=1, [FromQuery] int pageSize=1000)
        {
           var walks = await _walkRepository.GetAllAsync(filterOn, filterQuery,sortBy,isAscending?? true,pageNumber,pageSize);

            return Ok(_mapper.Map<List<WalkDTO>>(walks));
        }


        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize] // Reader and Writer can Read data
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await _walkRepository.GetAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDTO>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromBody] UpdateWalkDTO updateModel, Guid id)
        {

            var newWalk = _mapper.Map<Walk>(updateModel);
            newWalk = await _walkRepository.UpdateAsync(newWalk, id);

            if (newWalk == null)
            {
                return NotFound(); 
            }

            return Ok(_mapper.Map<WalkDTO>(newWalk));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walk = await _walkRepository.DeleteAsync(id);
            if(walk == null)
                return NotFound();

            return Ok(_mapper.Map<WalkDTO>(walk));
        }
    }
}
