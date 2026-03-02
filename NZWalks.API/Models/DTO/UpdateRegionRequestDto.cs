using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO {
    public class UpdateRegionRequestDto {

        [Required]
        [MinLength(3, ErrorMessage = "Code needs to be at least 3 characters long")]
        [MaxLength(3, ErrorMessage = "Code has to be 3 characters long")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name shouldn't surpass 100 characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
