using Country_explorer_API.Models;
using Country_explorer_API.Services;
using Moq;
using Moq.Protected;
using Shouldly;
using System.Net;
using System.Text;
using System.Text.Json;
using Country_explorer_API.Exceptions;
using Xunit;
using RichardSzalay.MockHttp;

namespace Country_explorer_API.Tests
{
    public class CountryServiceTests
    {
        private readonly CountryService _countryService;
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private const string BaseApiUrl = "https://restcountries.com/v3.1/";

        public CountryServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();

            ConfigureHttpClientFactory();

            _countryService = new CountryService(_httpClientFactoryMock.Object);
        }

        private void ConfigureHttpClientFactory()
        {
            _httpClientFactoryMock
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(_httpMessageHandlerMock.Object));
        }

        [Fact]
        public async Task GetAllCountries_Should_Return_ListAsync()
        {
            // Arrange
            var expectedData = new List<CountryViewModel>
            {
                new CountryViewModel { Name = new CountryName { Common = "Afghanistan" } },
                new CountryViewModel { Name = new CountryName { Common = "Brazil" } },
                new CountryViewModel { Name = new CountryName { Common = "Canada" } }
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedData), Encoding.UTF8, "application/json"),
            };

            _httpMessageHandlerMock.Protected()
                                  .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                                  .ReturnsAsync(responseMessage);

            // Act
            var result = await _countryService.GetAllCountries();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count() > 2);
            Assert.Equal("Afghanistan", result.First().Name.Common);
            Assert.True(result.All(country => country.Name != null));
        }


        [Fact]
        public async Task GetAllCountries_Success()
        {
            // Arrange
            var httpClient = new HttpClient(new HttpClientHandler());
            var actualData = await httpClient.GetStringAsync($"{BaseApiUrl}all");
            var expectedData = JsonSerializer.Deserialize<List<CountryViewModel>>(actualData)
                .OrderBy(c => c.Name?.Common)
                .ToList();

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(actualData, Encoding.UTF8, "application/json"),
            };

            _httpMessageHandlerMock.Protected()
                                  .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                                  .ReturnsAsync(responseMessage);

            // Act
            var result = await _countryService.GetAllCountries();

            // Assert
            Assert.Equal(expectedData, result, new CountryViewModelEqualityComparer());
        }

        [Fact]
        public async Task GetCountryDetails_ThrowsServiceException()
        {
            // Arrange
            const string countryCode = "INVALID_CODE";

            // Mock HttpClient to simulate a 404 response
            var mockHttp = new MockHttpMessageHandler();
            MockHttpMessageHandlerExtensions.When(mockHttp, $"{BaseApiUrl}alpha/{countryCode}")
                    .Respond(HttpStatusCode.NotFound);
            var httpClient = new HttpClient(mockHttp);

            // Use IHttpClientFactory to create a client with the mocked handler
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var countryService = new CountryService(httpClientFactoryMock.Object);

            // Act and Assert
            await Assert.ThrowsAsync<CountryServiceException>(() => countryService.GetCountryByCode(countryCode));
        }


        [Fact]
        public async Task GetCountryByCode_Should_Return_UnitedStates_When_Code_Is_US_Async()
        {
            // Arrange
            const string countryCode = "us";

            // Mock the HTTP client and handler
            var mockHttp = new MockHttpMessageHandler();
            var httpClient = new HttpClient(mockHttp);

            // Use IHttpClientFactory to create a client with the mocked handler
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var countryService = new CountryService(httpClientFactoryMock.Object);

            // Mock the response for the specific URL
            var expectedResponse = new CountryDetailViewModel
            {
                Name = new CountryName { Common = "United States" }
            };

            mockHttp.When($"{BaseApiUrl}alpha/{countryCode}")
                    .Respond(HttpStatusCode.OK, new StringContent(JsonSerializer.Serialize(expectedResponse)));

            // Act
            var result = await countryService.GetCountryByCode(countryCode);

            // Assert
            result.ShouldNotBeNull();
            result.Name.Common.ShouldBe("United States");
        }
    }
}