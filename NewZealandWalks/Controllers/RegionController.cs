using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewZealandWalks.Data;
using NewZealandWalks.Models.DTO;
using NewZealandWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Repository;
using NewZealandWalks.Mapping;
using AutoMapper;

namespace NewZealandWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegionController : ControllerBase
    {
        /// <summary>
        /// Controller created for using CRUD operation using Entity Framework for Regions 
        /// Used AutoMapper Here , Configured in Mapping => AutoMapperProfile.cs
        /// </summary>
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _automapper;

        public RegionController( IRegionRepository regionRepository ,IMapper automapper )
        {
            _regionRepository = regionRepository;
            _automapper = automapper;
        }


        // Get All region from the Table
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllRegion() {
            var Regionsdomain = await _regionRepository.GetListAsync();
            return Ok(_automapper.Map<List<RegionDto>>(Regionsdomain));
        }

        //Get Method to Retrieve the Regions based on the Id Present 
        //If not found Return not Found method
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionByID([FromRoute]Guid id)
        {
            var region = await _regionRepository.GetRegionByIDAsync(id);
            if (region == null) {
                return NotFound();
            }
            return Ok(_automapper.Map<RegionDto>(region));
        }

        //Add method to Add New Regions
        [HttpPost]
        [Route("Addregion")]
        public async Task<IActionResult> AddRegions([FromBody] AddRegionDto addregion){
            Region? region = _automapper.Map<Region>(addregion);
            region = await _regionRepository.AddregionAsync(region);
            if (region == null)
            {
                return BadRequest();
            }
            var regionDto = _automapper.Map<RegionDto>(region);
            return CreatedAtAction(nameof(GetRegionByID), new { regionDto.Id },regionDto);
        }

        //Update method to Update the region Entity based on the Id
        [HttpPut]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> UpdateRegionByID([FromRoute] Guid id, [FromBody] UpdateRegionDto UpdateRegion) {

            Region? Region = _automapper.Map<Region>(UpdateRegion);
            Region = await _regionRepository.UpdateRegionByIDAsync(id, Region);
            if (Region == null) {
                return NotFound();
            }

            var Regiondto = _automapper.Map<RegionDto>(Region);

            return Ok(Regiondto);
        }


        //Delete method to delete based on the ID
        [HttpDelete]
        [Route("Delete/{Id:Guid}")]
        public async Task<IActionResult> DeleteregionById([FromRoute] Guid Id)
        {

            Region? region = await _regionRepository.DeleteRegionByIdAsync(Id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }

}
