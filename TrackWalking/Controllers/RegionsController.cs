using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.CustomActionFilters;
using NZWalks.Data;
using NZWalks.DTOs.Region;
using NZWalks.Interfaces;
using NZWalks.Mappers;
using NZWalks.Models;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RegionsController : ControllerBase
    {
     
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository,
            IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Authorize] // Reader and Writer can Read data
        public async Task<IActionResult> GetAll(string? filterOn = null, string? filterQuery = null,
                                        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var regions = await _regionRepository.GetAllAsync(filterOn, filterQuery,pageNumber,pageSize);
            //var regionsDTOs = regions.Select(r => r.ToRegionDto()).ToList();
  
            return Ok(_mapper.Map<List<RegionDTO>>(regions));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize] // Reader and Writer can Read data
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetAsync(id);

            if (region == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(region));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateRegionDTO model)
        {
          
           var region = _mapper.Map<Region>(model);

           region = await _regionRepository.CreateAsync(region);

            if (region == null)
                return BadRequest(ModelState);

            // To display it to the user
            var regionDto = _mapper.Map<RegionDTO>(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromBody] UpdateRegionDTO model, [FromRoute] Guid id)
        {
          
            var region = _mapper.Map<Region>(model);

            region = await _regionRepository.UpdateAsync(region, id);

            if (region == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(region));

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region == null)
                return NotFound();

            return Ok(_mapper.Map<RegionDTO>(region));
        }

    }
}
