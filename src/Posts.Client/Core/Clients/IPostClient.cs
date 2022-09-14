using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Posts.Client.Core.Models;

namespace Posts.Client.Core.Clients;

public interface IPostClient
{
    Task<ICollection<Post>> GetPosts();

    Task<Post> GetPostById(int id);

    Task<Post> CreatePost(CreatePost newPost);
}
