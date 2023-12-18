using Country_explorer_API.Interfaces;
using Country_explorer_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Country_explore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCountries()
        {
            var response = await _countryService.GetAllCountries();
            return Ok(response);
        }

        [HttpGet("{countryCode}")]
        [ProducesResponseType(typeof(CountryDetailViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCountryDetails(string countryCode)
        {
            var response = await _countryService.GetCountryByCode(countryCode);
            return Ok(response);
        }
    }
}
