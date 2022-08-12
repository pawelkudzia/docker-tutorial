using Microsoft.AspNetCore.Mvc.Testing;
using WebService.Api;

namespace WebService.Tests.EndToEnd.Controllers;

public class ApiTestControllerTests : TestControllerBase
{
    private readonly string _basePath = "/api/test";

    public ApiTestControllerTests(WebApplicationFactory<Program> server) : base(server)
    {
    }

    [Fact]
    public async Task Test_should_return_valid_response()
    {
        // arrange
        int expectedResponseStatusCode = 200;

        // act
        var response = await Client.GetAsync(_basePath);
        int actualResponseStatusCode = (int)response.StatusCode;

        // assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(expectedResponseStatusCode, actualResponseStatusCode);
    }
}
