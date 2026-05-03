// This file contains API tests written in C# using xUnit.
// HttpClient is used to make API calls (GET, POST).
// Each test checks status codes and basic response fields.

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

public class JsonPlaceholderApiTests
{
    // Creating one HttpClient object to use in all tests
    // This avoids creating it again and again
    private readonly HttpClient _client;

    public JsonPlaceholderApiTests()
    {
        // Setting base URL so we don’t have to repeat it in every request
        _client = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };
    }

    [Fact]
    public async Task GetUser_ShouldReturnValidUserData()
    {
        // Step 1: Send GET request to fetch user with id = 1
        HttpResponseMessage response = await _client.GetAsync("users/1");

        // Step 2: Check if status code is 200 (request successful)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Step 3: Read response body as string
        string responseBody = await response.Content.ReadAsStringAsync();

        // Step 4: Convert JSON string into object so we can read fields
        using JsonDocument json = JsonDocument.Parse(responseBody);
        JsonElement root = json.RootElement;

        // Step 5: Check if important fields are present
        // We are not checking full data, just basic structure
        Assert.True(root.TryGetProperty("id", out _));
        Assert.True(root.TryGetProperty("name", out _));
        Assert.True(root.TryGetProperty("email", out _));
    }

    [Fact]
    public async Task CreatePost_ShouldReturnCreatedPost()
    {
        // Step 1: Create sample data to send in request body
        var newPost = new
        {
            title = "Test Title",
            body = "This is a test post",
            userId = 1
        };

        // Step 2: Convert object to JSON string
        string jsonContent = JsonSerializer.Serialize(newPost);

        // Step 3: Convert JSON string into HTTP request content
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Step 4: Send POST request
        HttpResponseMessage response = await _client.PostAsync("posts", content);

        // Step 5: Check if status code is 201 (created)
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        // Step 6: Read response body
        string responseBody = await response.Content.ReadAsStringAsync();

        // Step 7: Convert response into JSON object
        using JsonDocument json = JsonDocument.Parse(responseBody);
        JsonElement root = json.RootElement;

        // Step 8: Validate returned data
        // Checking if values match what we sent
        Assert.True(root.TryGetProperty("id", out _)); // new id should be generated
        Assert.Equal("Test Title", root.GetProperty("title").GetString());
        Assert.Equal("This is a test post", root.GetProperty("body").GetString());
        Assert.Equal(1, root.GetProperty("userId").GetInt32());
    }

    [Fact]
    public async Task GetNonExistentUser_ShouldReturn404()
    {
        // Step 1: Send request for user that does not exist
        HttpResponseMessage response = await _client.GetAsync("users/999");

        // Step 2: Check if status code is 404 (not found)
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        // Step 3: Read response body (optional check)
        string responseBody = await response.Content.ReadAsStringAsync();

        // Step 4: In this API, response may be empty or {}
        // So we just check it is not something unexpected
        Assert.True(string.IsNullOrEmpty(responseBody) || responseBody == "{}");
    }
}