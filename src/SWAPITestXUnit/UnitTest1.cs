using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SWAPITestXUnit
{
    public class CorrectnessOfData
    {
        private readonly HttpClient _client;

        public CorrectnessOfData()
        {
            _client = new HttpClient();
        }

        [Fact]
        public async Task ApiReturnsCorrectData()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.dev/api/people/1");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            // Check specific data fields
            Assert.Equal("Luke Skywalker", (string)json["name"]);
            Assert.Equal("19BBY", (string)json["birth_year"]);
            Assert.Equal("172", (string)json["height"]);
        }

        [Fact]
        public async Task ApiReturnsCorrectDataForPerson2()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.dev/api/people/2");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            // Check specific data fields
            Assert.Equal("C-3PO", (string)json["name"]);
            Assert.Equal("112BBY", (string)json["birth_year"]);
            Assert.Equal("167", (string)json["height"]);
        }

        [Fact]
        public async Task ApiReturnsCorrectDataForPerson2V2()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.dev/api/people/2");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            // Check specific data fields
            Assert.Equal("C-3PO", (string)json["name"]);
            Assert.Equal("112BBY", (string)json["birth_year"]);
            Assert.Equal("167", (string)json["height"]);

            // Additional checks
            Assert.NotNull(json["name"]);
            Assert.InRange<int>((int)json["height"], 0, 300);
            Assert.True(((string)json["name"]).Length <= 50);
        }

        [Fact]
        public async Task ApiReturnsNotFoundForInvalidInput()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.dev/api/people/9999");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ApiReturnsErrorForInvalidInput()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.dev/api/people/invalid");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ApiReturnsValidationErrorForInvalidData()
        {
            // Arrange
            var invalidData = new { name = "" }; // Assuming "name" is a required field
            var jsonContent = new StringContent(JsonConvert.SerializeObject(invalidData), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://swapi.dev/api/people")
            {
                Content = jsonContent
            };

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [Fact]
        public async Task EndpointIsAvailable()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.dev/api/people/1");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}