using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Posts.Client.Configuration;
using Posts.Client.Core.Clients;
using Posts.Client.Core.Models;
using System.Net.Mime;

namespace Posts.Client.Clients;

public class PostClient : IPostClient
{
    private readonly HttpClient _httpClient;

    private readonly PostOptions _postOptions;

    public PostClient(
        HttpClient httpClient, 
        IOptionsSnapshot<PostOptions> postOptions)
    {
        _httpClient = httpClient;
        _postOptions = postOptions.Value;
    }

    public async Task<Post> CreatePost(CreatePost newPost)
    {
        var uri = _postOptions.BaseAddress.ToString();

        var content = new StringContent(
            JsonSerializer.Serialize(newPost),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        var result = await _httpClient.PostAsync(uri, content);

        var stringResult = await result.Content.ReadAsStringAsync();

        var post = JsonSerializer.Deserialize<Post>(stringResult);

        return post;
    }

    public async Task<Post> GetPostById(int id)
    {
        var uri = _postOptions.BaseAddress.ToString();

        var result = await _httpClient.GetAsync($"{uri}/{id}");

        var stringResult = await result.Content.ReadAsStringAsync();

        var post = JsonSerializer.Deserialize<Post>(stringResult);

        return post;
    }

    public async Task<ICollection<Post>> GetPosts()
    {
        var uri = _postOptions.BaseAddress.ToString();

        var result = await _httpClient.GetAsync($"{uri}?userId=99999");

        var stringResult = await result.Content.ReadAsStringAsync();

        var posts = JsonSerializer.Deserialize<ICollection<Post>>(stringResult);

        return posts;
    }
}
