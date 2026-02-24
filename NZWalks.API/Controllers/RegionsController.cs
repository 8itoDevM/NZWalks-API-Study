using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers {
    
    // https://localhost:7080/api/regoins
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        // GET: https://localhost:7080/api/regoins
        [HttpGet]
        public IActionResult GetAll() {
            var regions = new List<Region> {
                new Region{
                    Id = Guid.NewGuid(),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c9/Auckland_skyline_-_May_2024_%282%29.jpg"
                },
                new Region{
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://wellingtonnz.bynder.com/transform/939a86a1-879d-4585-9271-507885862f76/Mount-Vic-Lookout-Scenic-1"
                }
            };

            return Ok(regions);

        }
    }
}
