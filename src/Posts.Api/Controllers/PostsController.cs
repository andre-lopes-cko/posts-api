using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Posts.Api.Resources;
using Posts.Client.Core.Clients;
using Posts.Client.Core.Models;

namespace Posts.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostClient _client;

    public PostsController(IPostClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostResource>>> GetPosts()
    {
        return Ok(await _client.GetPosts());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<PostResource>>> GetPostById(int id)
    {
        return Ok(await _client.GetPostById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<IEnumerable<PostResource>>> CreatePost(CreatePostResource newPost)
    {
        if (string.IsNullOrWhiteSpace(newPost.Title))
        {
            return BadRequest("Title required");
        }

        if (string.IsNullOrWhiteSpace(newPost.Body))
        {
            return BadRequest("Body required");
        }

        var post = new CreatePost
        {
            Title = newPost.Title,
            Body = newPost.Body,
        };

        var createdPost = await _client.CreatePost(post);

        var postResource = new PostResource
        {
            Id = createdPost.Id,
            Title = createdPost.Title,
            Body = createdPost.Body
        };

        return Created(postResource.Id.ToString(), postResource);
    }
}
