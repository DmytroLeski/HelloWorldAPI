using System.Net.Http;
using System.Threading.Tasks;

namespace Tests;

public class HelloControllerTests
{
    private readonly HttpClient _client;

    public HelloControllerTests()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        _client = new HttpClient(handler)
        {
            BaseAddress = new System.Uri("http://localhost:7184/")
        };
    }

    [Theory]
    [InlineData("World", "Hello World")]
    [InlineData("Student", "Hello Student")]
    public async Task GetMessage_ReturnsCorrectString(string input, string expected)
    {
        // Act
        var response = await _client.GetAsync($"Hello/{input}"); 
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.True(response.IsSuccessStatusCode); 
        Assert.Equal(expected, result);
    }
}