using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Data;
using NZWalks.DTOs.Region;
using NZWalks.Mappers;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _context.Regions.ToList();

            var regionsDTOs = regions.Select(r => r.ToRegionDto()).ToList();

            return Ok(regionsDTOs);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
                return NotFound();

            return Ok(region.ToRegionDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRegionDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var region = model.FromCreateRegionToRegion();

            _context.Regions.Add(region);   
            _context.SaveChanges();

            // To display it to the user
            var regionDto = region.ToRegionDto();

            return CreatedAtAction(nameof(GetById),new {id = region.Id}, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromBody] UpdateRegionDTO model, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var region = _context.Regions.FirstOrDefault(r => r.Id == id);
            if(region == null)
                return NotFound();

            region.Code = model.Code;
            region.Name = model.Name;   
            region.RegionImageUrl = model.RegionImageUrl;

            _context.SaveChanges();

            var regionDto = region.ToRegionDto();

            return Ok(regionDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var region = _context.Regions.FirstOrDefault(r => r.Id == id);

            if (region == null)
                return NotFound();
            _context.Regions.Remove(region);
            _context.SaveChanges();

            return Ok();
        }

    }
}
