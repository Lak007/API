using Microsoft.AspNetCore.Mvc;
using NewZealandWalks.Models.DTO;
using NewZealandWalks.Repository;
using System.Threading.Tasks;
using AutoMapper;
using NewZealandWalks.Models.Domain;
using System;

namespace NewZealandWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        /// <summary>
        /// Walks Controller with Entity framework and Automapper combined used
        /// </summary>
        private readonly IWalkRepository _repository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository repository ,  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddWalks")]
        public async Task<IActionResult> AddNewWalk([FromBody] AddWalkRequest Walkrequest) {
            var Walk =  _mapper.Map<Walks>(Walkrequest);
            Walk =await _repository.AddWalkAsync(Walk);
            return Ok(_mapper.Map<WalksDto>(Walk));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetWalkByID(Guid id)
        {
            Walks walk = await _repository.GetWalksbyIdAsync(id);
            if (walk == null) {
                return BadRequest();
            }
            var walksdto = _mapper.Map<WalksDto>(walk);
            return Ok(walksdto);
        }

        [HttpPut]
        [Route("Update/{id}")]

        public async Task<IActionResult> UpdateWalksById(Guid id, [FromBody] AddWalkRequest walkrequest) {

            var walk = _mapper.Map<Walks>(walkrequest);
            walk = await _repository.UpdateWalksById(id, walk);
            if (walk == null) {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWalksById(Guid id)
        {

            Walks walk = await _repository.DeleteWalksById(id);
            if (walk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalksDto>(walk));
        }
    }
}
