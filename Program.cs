using System.Reflection;
using MassTransit;
using MinimalWebApiMassTransit.Emails.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(c =>
{
    c.SetKebabCaseEndpointNameFormatter();
    c.SetInMemorySagaRepositoryProvider();
    
    var entryAssembly = Assembly.GetEntryAssembly();
    c.AddConsumers(entryAssembly);
    c.AddSagaStateMachines(entryAssembly);
    c.AddSagas(entryAssembly);
    c.AddActivities(entryAssembly);
    
    c.UsingInMemory((ctx, cfg) =>
    {
        cfg.ConfigureEndpoints(ctx);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/subscribe", async (IBus bus) =>
    {
        bus.Publish(new SubscribeToNewsletter("test@test.at"));
    })
    .WithName("Subscribe")
    .WithOpenApi();

app.Run();
