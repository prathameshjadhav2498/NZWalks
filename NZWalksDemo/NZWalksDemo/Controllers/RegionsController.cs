using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalksDemo.Data;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _repository;
        private readonly IMapper _mapper;
        //private readonly ITokenHandler _tokenHandler;

        public RegionsController(IRegionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            //_tokenHandler = tokenHandler;
        }

        [HttpGet("getallregions")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _repository.GetAllAsync();
            var regionsDtos = _mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsDtos);
        }

        [HttpGet("getregionbyid/{id:guid}")]
        //[Route("getregionbyid/{id:guid}")]
        [ActionName("GetRegionByIdAsync")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var region = await _repository.GetByIdAsync(id);
            var regioDto = _mapper.Map<RegionDto>(region);

            if (regioDto != null)
                return Ok(regioDto);

            return NotFound();
        }

        [HttpPost("addregion")]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest regionRequest)
        {
            //convert DTO to Domain
            var region = new Region
            {
                Area = regionRequest.Area,
                Lat = regionRequest.Lat,
                Long = regionRequest.Long,
                Name = regionRequest.Name,
                Population = regionRequest.Population,
                Code = regionRequest.Code
            };

            // Pass Details to repo
            region = await _repository.AddAsync(region);

            //convert back to DTO
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionByIdAsync), new { id = regionDto.Id }, regionDto);
        }

        [HttpDelete("deleteregion/{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //get region from DB
            var region = await _repository.DeleteAsync(id);

            //if null Not Found
            if (region == null)
            {
                return NotFound();
            }

            //convert response back to DTO
            var regionDto = _mapper.Map<RegionDto>(region);

            //return OK response
            return Ok(regionDto);
        }

        [HttpPut("updateregion/{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, RegionDto updateRegionDto)
        {
            //convert Dto to model
            var region = _mapper.Map<Region>(updateRegionDto);

            //update region using repository
            region = await _repository.UpdateAsync(id, region);

            //return null if not found
            if (region==null)
            {
                return NotFound();
            }
            //domain to dto
            var newRegion = _mapper.Map<RegionDto>(region);

            //return OK
            return Ok(newRegion);
        }


    }
}
