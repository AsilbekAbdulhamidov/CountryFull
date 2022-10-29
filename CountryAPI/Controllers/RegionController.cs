using CountryAPI.Services;
using Data1.DTO;
using Data1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RegionController : Controller
    {
        
        private readonly IServices<Region, RegionDto> _servics;

        public RegionController(IServices<Region, RegionDto> regSrv)
        {
            _servics = regSrv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _servics.Get());

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegionDto DTO)
        {
            await _servics.Create(DTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _servics.Delete(id));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegionDto DTO)
        {


            return Ok(await _servics.UpdateCountry(id, DTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _servics.Get(id));
        }
    }
}
