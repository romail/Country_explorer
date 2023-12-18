using Country_explorer_API.Models;

namespace Country_explorer_API.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryViewModel>> GetAllCountries();
        Task<CountryDetailViewModel> GetCountryByCode(string countryCode);
    }
}
