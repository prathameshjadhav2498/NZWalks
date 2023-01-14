using AutoMapper;
using NZWalksDemo.Models.Domain;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
            //CreateMap<AddWalkRequest, WalkDto>().ReverseMap();
            //CreateMap<UpdateWalkDto, Walk>().ReverseMap();
            CreateMap<Walk, UpdateWalkDto>().ReverseMap();
        }
    }
}
