using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers {
    
    // https://localhost:7080/api/regoins
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper) {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: https://localhost:7080/api/regoins
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            //Get data from databsae perform CRUD operations - Domain models
            var regionDomain = await regionRepository.GetAllAsync();

            // Return DTOs to client
            return Ok(mapper.Map<List<RegionDto>>(regionDomain));

        }

        // GET single region by ID
        // GET: https://localhost:7080/api/regoins/{id}
        [HttpGet]
        [Route("{id}:Guid")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            //var region = dbContext.Regions.Find(id); // can only be used with the ID property

            var regionDomain = await regionRepository.GetByIdAsync(id);

            if(regionDomain == null) {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST that creates a new Region in the Db
        // POST: https://localhost:7080/api/regoins
        [HttpPost]
        [ValidateModelAtribute]
        public async Task<IActionResult> Create([FromBody] AddRegionRquestDto addRegionRquestDto) {
            
            // Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(addRegionRquestDto);

            // Use Domain Model to create Region
            regionDomain = await regionRepository.CreateAsync(regionDomain);

            // convert Domain back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        // Update region
        // PUT: https://localhost:7080/api/regoins/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModelAtribute]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
            var regionDomain = mapper.Map<Region>(updateRegionRequestDto);

            regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

            if(regionDomain == null) {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // Delete region
        // DELETE: https://localhost:7080/api/regoins/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var regionDomain = await regionRepository.DeleteAsync(id);

            if(regionDomain == null) {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }
    }
}
