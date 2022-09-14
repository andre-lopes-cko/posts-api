using Microsoft.Extensions.DependencyInjection;
using Posts.Client.Clients;
using Posts.Client.Core.Clients;

namespace Posts.Client.Extensions;

public static class ClientExtensions
{
    public static void AddClient(this IServiceCollection services)
    {
        services.AddHttpClient<IPostClient, PostClient>();
    }
}
