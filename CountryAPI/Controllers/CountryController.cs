using CountryAPI.Services;
using Data1.DTO;
using Data1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CountryController : ControllerBase
    {
        private readonly IServices<Country, CounrtyDto> _servics;

        public CountryController(IServices<Country, CounrtyDto> servics)
        {
            _servics = servics;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _servics.Get());

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CounrtyDto countryDTO)
        {
            return Ok(_servics.Create(countryDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _servics.Delete(id));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CounrtyDto countryDTO)
        {
            return Ok(await _servics.UpdateCountry(id, countryDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _servics.Get(id));
        }

    }
}
