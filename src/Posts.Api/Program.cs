using Posts.Client.Clients;
using Posts.Client.Configuration;
using Posts.Client.Core.Clients;
using Posts.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postOptionsSection = builder.Configuration.GetSection(PostOptions.Key);
var postOption = postOptionsSection.Get<PostOptions>();

builder.Services.Configure<PostOptions>(postOptionsSection);

builder.Services.AddHttpClient<IPostClient, PostClient>();
builder.Services.AddClient();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
