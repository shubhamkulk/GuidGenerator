using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace GuidGenerator
{
    public class Logger
    {
        private static readonly string LOG_CONFIG_FILE = "log4net.config";

        private static readonly ILog logger = LogManager.GetLogger(typeof(Logger));

        static Logger()
        {
            SetupLog4Net();
        }

        public static void Log(string message, Exception exception = null)
        {
            if (exception != null)
                logger.Error($"{message}", exception);
            else
                logger.Info(message);
        }

        private static void SetupLog4Net()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}
