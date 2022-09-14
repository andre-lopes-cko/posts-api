using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.Client.Configuration;

public class PostOptions
{
    public const string Key = "Post";

    public Uri BaseAddress { get; set; }
}
