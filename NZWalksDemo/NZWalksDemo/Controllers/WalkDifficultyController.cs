using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;
using NZWalksDemo.Models.DTO;

namespace NZWalksDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository _repository;
        private readonly IMapper _mapper;
        public WalkDifficultyController(IWalkDifficultyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("getallwalkdifficulties")]
        public async Task<IActionResult> GetAllDifficulties()
        {
            var result = await _repository.GetAllAsync();
            var res = _mapper.Map<List<WalkDifficultyDto>>(result);

            return Ok(res);
        }
        [ActionName("GetDifficultyById")]
        [HttpGet("getwalkdifficultiesbyid/{id:guid}")]
        public async Task<IActionResult> GetDifficultyById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result != null)
            {
                var res = _mapper.Map<WalkDifficultyDto>(result);
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPost("adddifficulty")]
        public async Task<IActionResult> AddDifficulty(WalkDifficultyDto wtRequest)
        {
            var domainObj = _mapper.Map<WalkDifficulty>(wtRequest);
            var res = await _repository.AddAsync(domainObj);
            //if (res != null)
            //{
            var result = _mapper.Map<WalkDifficultyDto>(res);
            return CreatedAtAction(nameof(GetDifficultyById), new { Id = res.Id }, res);
            //}
            //return null;
        }

        [HttpPut("updatedifficulty")]
        public async Task<IActionResult> UpdateDifficulty(Guid id, WalkDifficultyDto updateWalkDto)
        {
            var res = _mapper.Map<WalkDifficulty>(updateWalkDto);
            res = await _repository.UpdateAsync(id, res);

            if (res != null)
            {
                var result = _mapper.Map<WalkDifficultyDto>(res);

                return Ok(result);
            }
            return NotFound();
        }
    }
}
