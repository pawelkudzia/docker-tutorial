using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebService.Tests.Controllers
{
    public class ApiTestControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _server;
        private readonly HttpClient _client;
        private readonly string _basePath = "/api/test";

        public ApiTestControllerTests(WebApplicationFactory<Program> server)
        {
            _server = server;
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Test()
        {
            // arrange
            int expectedResponseStatusCode = 200;

            // act
            var response = await _client.GetAsync(_basePath);
            int actualResponseStatusCode = (int)response.StatusCode;

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedResponseStatusCode, actualResponseStatusCode);
        }
    }
}
