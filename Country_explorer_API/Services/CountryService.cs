using Country_explorer_API.Exceptions;
using Country_explorer_API.Interfaces;
using Country_explorer_API.Models;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Net;
using System.Text.Json;

namespace Country_explorer_API.Services
{
    public class CountryService : ICountryService
    {
        private const string BaseApiUrl = "https://restcountries.com/v3.1/";
        private readonly HttpClient _httpClient;
        private IEnumerable<CountryViewModel> Data;

        public CountryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }


        /// <summary>
        /// Get all countries.
        /// </summary>
        /// <returns>All countries.</returns>
        public async Task<List<CountryViewModel>> GetAllCountries()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{BaseApiUrl}all");

                string json = await response.Content.ReadAsStringAsync();

                Data = JsonSerializer.Deserialize<IEnumerable<CountryViewModel>>(json);

                return Data.OrderBy(c => c.Name?.Common)
                    .ToList();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new CountryNotFoundException("The countries resource was not found.", ex);
            }
            catch (Exception ex)
            {
                throw new CountryServiceException("Error fetching countries from the external API.", ex);
            }
        }


        /// <summary>
        /// Search by Alpha 2 code or Alpha 3 code.
        /// </summary>
        /// <param name="countryCode">Alpha code.</param>
        /// <returns>The country which code is provided.</returns>
        public async Task<CountryDetailViewModel> GetCountryByCode(string countryCode)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseApiUrl}alpha/{countryCode}");

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new CountryNotFoundException($"Country with code {countryCode} was not found.");
                    }

                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}.");
                }

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<CountryDetailViewModel>>(json).FirstOrDefault();
            }
            catch (HttpRequestException ex)
            {
                throw new CountryServiceException($"Error fetching details for country {countryCode}.", ex);
            }
            catch (Exception ex)
            {
                throw new CountryServiceException($"Error fetching details for country {countryCode}.", ex);
            }
        }
    }
}
