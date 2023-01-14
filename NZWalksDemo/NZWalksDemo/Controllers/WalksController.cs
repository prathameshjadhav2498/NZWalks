using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _repository;
        public WalksController(IMapper mapper, IWalkRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("getallwalks")]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walks = await _repository.GetAllAsync();
            var walksdtos = _mapper.Map<List<WalkDto>>(walks);
            return Ok(walksdtos);
        }
        [ActionName("GetByIdAsync")]
        [HttpGet("getwalkdetailsbyid/{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var walkdetails = await _repository.GetByIdAsync(id);
            var walksdtos = _mapper.Map<WalkDto>(walkdetails);

            if (walksdtos != null)
            {
                return Ok(walksdtos);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("addwalk")]
        public async Task<IActionResult> AddWalkAsync(AddWalkRequest addWalkRequest)
        {
            //DTO to Domain
            var walkDomain = new Walk
            {
                Name = addWalkRequest.Name,
                Length = addWalkRequest.Length,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId,
                CreatedBy = "a",
                CreatedOn = DateTime.UtcNow
            };
            //pass to repo
            walkDomain = await _repository.AddAsync(walkDomain);
            //domain to DTO
            var walkDto = _mapper.Map<WalkDto>(walkDomain);


            return CreatedAtAction(nameof(GetByIdAsync), new { id = walkDto.Id }, walkDto);

        }

        [HttpDelete("deletewalk/{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsyncById(Guid id)
        {
            var walk = await _repository.DeleteAsync(id);
            if (walk != null)
            {
                var walkDto = _mapper.Map<WalkDto>(walk);
                return Ok(walkDto);
            }
            return NotFound();
        }

        [HttpPut("updatewalk/{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, UpdateWalkDto updateWalkDto)
        {
            //convert Dto to model
            var walk = _mapper.Map<Walk>(updateWalkDto);

            //update region using repository
            walk = await _repository.UpdateAsync(id, walk);

            //return null if not found
            if (walk == null)
            {
                return NotFound();
            }
            //domain to dto
            var newWalk = _mapper.Map<WalkDto>(walk);

            //return OK
            return Ok(newWalk);
        }

    }
}
