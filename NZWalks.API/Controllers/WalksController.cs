using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers {

    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository) {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        public IMapper Mapper { get; }

        // CREATE walk
        // POST:
        [HttpPost]
        [ValidateModelAtribute]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto) {
            // Map DTO to Domain
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

            // Insert Walk in db asynchronously
            await walkRepository.CreateAsync(walkDomain);

            // Return walk created by mapping domain to DTO
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        //filtering - GET:/api/walks?filterOn=Name&fitlerQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending) {
            var walkDomain = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true);

            return Ok(mapper.Map<List<WalkDto>>(walkDomain));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id) {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if(walkDomain == null) {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateModelAtribute]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto) {
            var walkDomain = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);

            if(walkDomain == null) {
                return NotFound();
            }

            return Ok(mapper.Map<Walk>(walkDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var deleteDomainWalk = await walkRepository.DeleteAsync(id);

            if(deleteDomainWalk == null) {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deleteDomainWalk));
        }
    }
}
