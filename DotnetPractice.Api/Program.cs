using DotnetPractice.Api.Common.Mapping;
using DotnetPractice.Api.Endpoints;
using DotnetPractice.Core;
using DotnetPractice.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMappings();
builder.Services.AddInfrastructure(builder.Configuration)
                .AddCore();

var app = builder.Build();

app.MapTeamEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();