using AutoMapper;
using NZWalksDemo.Models.Domain;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Profiles
{
    public class WalkDifficultyProfile:Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
        }
    }
}
    