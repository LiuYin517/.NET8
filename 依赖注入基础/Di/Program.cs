// See https://aka.ms/new-console-template for more information

using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<IConfigService,EnvVarConfigService>();
services.AddScoped<IMailServices,MailService>();
services.AddScoped<ILogProvider,LogProvider>();

using var sp = services.BuildServiceProvider();

    var mailService = sp.GetRequiredService<IMailServices>();
    mailService.Send("Hello","xxxx@1233.com","Hello,大福宝");
    


