using ConfigServices;
using LogServices;

namespace MailServices;

public class MailService:IMailServices

{
    private readonly ILogProvider _logProvider;

    private readonly IConfigService _configService;

    public MailService(ILogProvider logProvider, IConfigService configService)
    {
        _logProvider = logProvider;
        _configService = configService;
    }
    
    public void Send(string title, string to, string body)
    {
        _logProvider.Log("准备发送邮件");
        var smtpServer = _configService.GetValue("SmtpServer");
        var userName = _configService.GetValue("UserName");
        var password = _configService.GetValue("Password");
        Console.WriteLine($"邮件服务器地址{smtpServer},{userName},{password}");
       Console.WriteLine($"发送邮件，标题为{title},内容为{body},{to}");
    }
}