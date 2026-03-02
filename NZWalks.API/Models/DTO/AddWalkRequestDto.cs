using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO {
    public class AddWalkRequestDto {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name can't surpass 100 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        [Required(ErrorMessage = "Difficulty is required")]
        public Guid DifficultyId { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public Guid RegionId { get; set; }
    }
}
