using System;
using System.Text.Json;
using ApiBackend.DTOs;

namespace ApiBackend.Services;

public class PostsService : IPostsService
{
    private readonly HttpClient _httpClient;
    public PostsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PostDto>> Get()
    {
        System.Console.WriteLine(_httpClient.BaseAddress);
        var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
        var body = await result.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        var data = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);
        return (IEnumerable<PostDto>)data;
    }
}
