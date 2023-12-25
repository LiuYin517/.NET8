using Microsoft.Extensions.Logging;

namespace Log;

public class Test1(ILogger<Test1> logger)
{
    public void Dome()
    {
        logger.LogDebug("开始执行数据库同步");
        logger.LogDebug("连接数据库成功");
        logger.LogWarning("查找数据失败，重试第一次");
        logger.LogWarning("查找数据失败，重试第二次");
        logger.LogError("查找数据最终失败");
        try
        {
            File.ReadAllText("A:1.txt");
            logger.LogDebug("读取文件成功！");
        }
        catch (Exception e)
        {
            Console.WriteLine($"读取文件失败！，{e}");
            
        }
    }
}