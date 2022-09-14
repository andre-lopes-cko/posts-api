using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.Client.Core.Models;

public class CreatePost
{
    public string Title { get; set; }

    public string Body { get; set; }

    public int UserId { get; set; } = 99999;
}
