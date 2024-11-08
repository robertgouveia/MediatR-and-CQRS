using CqrsMediatr;
using CqrsMediatr.Behaviours;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Configuring MedaitR - Must have line
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddSingleton<FakeDataStore>();

// How you declare a behaviour
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();