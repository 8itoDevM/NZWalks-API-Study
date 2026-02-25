using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers {
    
    // https://localhost:7080/api/regoins
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository) {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        // GET: https://localhost:7080/api/regoins
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            //Get data from databsae - Domain models
            var regionDomain = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach(var regionsDomain in regionDomain) {
                regionsDto.Add(new RegionDto() { 
                    Id = regionsDomain.Id,
                    Code = regionsDomain.Code,
                    Name = regionsDomain.Name,
                    RegionImageUrl = regionsDomain.RegionImageUrl,
                });

            }

            // Return DTOs to client
            return Ok(regionsDto);

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

            var regionsDto = new RegionDto {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(regionsDto);
        }

        // POST that creates a new Region in the Db
        // POST: https://localhost:7080/api/regoins
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRquestDto addRegionRquestDto) {
            // Map DTO to Domain Model
            var regionDomain = new Region {
                Code = addRegionRquestDto.Code,
                Name = addRegionRquestDto.Name,
                RegionImageUrl = addRegionRquestDto.RegionImageUrl,
            };

            // Use Domain Model to create Region
            regionDomain = await regionRepository.CreateAsync(regionDomain);

            // convert Domain back to DTO

            var regionDto = new RegionDto {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id}, regionDto);
        }

        // Update region
        // PUT: https://localhost:7080/api/regoins/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
            var regionDomain = new Region {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl,
            };

            regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

            if(regionDomain == null) {
                return NotFound(); 
            }

            // Convert Domain to DTO
            var regionDto = new RegionDto {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(regionDto);
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

            var regionDto = new RegionDto {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(regionDto);
        }
    }
}
