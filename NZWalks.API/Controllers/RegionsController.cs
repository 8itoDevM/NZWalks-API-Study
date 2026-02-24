using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

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
            var regions = dbContext.Regions.ToList();

            return Ok(regions);

        }
    }
}
