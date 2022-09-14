using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.Api.Resources;

public class CreatePostResource
{
    public string? Title { get; set; }

    public string? Body { get; set; }
}
