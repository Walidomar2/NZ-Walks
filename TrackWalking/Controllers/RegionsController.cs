using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.DTOs.Region;
using NZWalks.Interfaces;
using NZWalks.Mappers;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
     
        private readonly IRegionRepository _regionRepository;
        public RegionsController(IRegionRepository regionRepository)
        {
           _regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
            var regionsDTOs = regions.Select(r => r.ToRegionDto()).ToList();

            return Ok(regionsDTOs);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetAsync(id);

            if (region == null)
                return NotFound();

            return Ok(region.ToRegionDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          var region = await _regionRepository.CreateAsync(model);

            if (region == null)
                return BadRequest(ModelState);
           
            // To display it to the user
            var regionDto = region.ToRegionDto();

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateRegionDTO model, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           var region = await _regionRepository.UpdateAsync(model,id);
            if (region == null)
                return NotFound();

            var regionDto = region.ToRegionDto();

            return Ok(regionDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region == null)
                return NotFound();

            var regionDto = region.ToRegionDto();

            return Ok(regionDto);
        }

    }
}
