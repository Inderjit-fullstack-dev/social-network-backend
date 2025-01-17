using AutoWrapper;
using SocialNetwork.Application;
using SocialNetwork.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    .AddApplicationDependencies(builder.Configuration)
    .AddDependencies(builder.Configuration)
    .AddInfrastructureDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { IsDebug = true });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
