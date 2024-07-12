using log4net;
using log4net.Config;

namespace Br.Com.Fiap.Api.Extensions
{
    public static class Log4netExtensions
    {
        public static void AddLog4net(this IServiceCollection services)
        {
			try
			{
				XmlConfigurator.Configure(new FileInfo("Log4net.config"));
				services.AddSingleton(LogManager.GetLogger(typeof(Program)));
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
