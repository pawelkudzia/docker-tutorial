using Microsoft.AspNetCore.Mvc.Testing;

namespace WebService.Tests.EndToEnd.Controllers;

public abstract class TestControllerBase : IClassFixture<WebApplicationFactory<Program>>
{
    protected WebApplicationFactory<Program> Server { get; }
    protected HttpClient Client { get; }

    public TestControllerBase(WebApplicationFactory<Program> server)
    {
        Server = server;
        Client = Server.CreateClient();
    }
}
