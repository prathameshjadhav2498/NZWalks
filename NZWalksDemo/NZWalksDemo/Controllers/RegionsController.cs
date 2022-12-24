using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksDemo.Data;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _repository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("getallregions")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _repository.GetAllAsync();
            var regionsDtos = _mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsDtos);
        }
    }
}
