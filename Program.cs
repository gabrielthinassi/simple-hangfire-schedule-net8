using Hangfire;
using Hangfire.MemoryStorage;
using simple_hangfire_schedule_net8.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

BackgroundJob.Enqueue(() => Console.WriteLine("Job rodou!"));

RecurringJob.AddOrUpdate("MyRecurringJob", () =>  Console.WriteLine("Job Recorrente Rodou!"), Cron.Minutely, 
    new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });

RecurringJob.AddOrUpdate<FilePurge>(
    "MyFilePurgeJob",
    x => x.PurgeFromDirectory(@"C:\Dev\TESTES\temp"),
    Cron.Daily,
    new RecurringJobOptions { TimeZone = TimeZoneInfo.Local }
);

app.Run();