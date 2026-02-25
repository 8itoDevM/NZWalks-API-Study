using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers {
    
    // https://localhost:7080/api/regoins
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext) {
            this.dbContext = dbContext;
        }

        // GET: https://localhost:7080/api/regoins
        [HttpGet]
        public IActionResult GetAll() {
            //Get data from databsae - Domain models
            var regionDomain = dbContext.Regions.ToList();

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
        public IActionResult GetById([FromRoute] Guid id) {
            //var region = dbContext.Regions.Find(id); // can only be used with the ID property

            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id); // can be used with any column from the db

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
        public IActionResult Create([FromBody] AddRegionRquestDto addRegionRquestDto) {
            // Map DTO to Domain Model
            var regionDomain = new Region {
                Code = addRegionRquestDto.Code,
                Name = addRegionRquestDto.Name,
                RegionImageUrl = addRegionRquestDto.RegionImageUrl,
            };

            // Use Domain Model to create Region
            dbContext.Regions.Add(regionDomain);
            dbContext.SaveChanges();

            // convert Domain back to DTO

            var regionDto = new RegionDto {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id}, regionDto);
        }
    }
}
