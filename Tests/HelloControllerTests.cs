using System.Net.Http;
using System.Threading.Tasks;

namespace Tests;

public class HelloControllerTests
{
    private readonly HttpClient _client;

    public HelloControllerTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("https://localhost:7184/"); 
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