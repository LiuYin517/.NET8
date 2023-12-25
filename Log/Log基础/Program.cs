// See https://aka.ms/new-console-template for more information

using Log;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var service = new ServiceCollection();
service.AddLogging(log =>
{
    log.AddConsole();
    log.SetMinimumLevel(LogLevel.Trace);
});
service.AddScoped<Test1>();

using var sp = service.BuildServiceProvider();
var test1 = sp.GetRequiredService<Test1>();
test1.Dome();