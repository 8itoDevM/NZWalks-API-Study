using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRquestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        }
    }
}
