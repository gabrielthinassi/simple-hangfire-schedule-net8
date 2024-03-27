using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

BackgroundJob.Enqueue(() => Console.WriteLine("Job rodou!"));

RecurringJob.AddOrUpdate("MeuJobRecorrente", () =>  Console.WriteLine("Job Recorrente Rodou!"), Cron.Minutely, 
    new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });

app.Run();