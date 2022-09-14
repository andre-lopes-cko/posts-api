using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Posts.Client.Core.Models;

public class Post
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }
}
