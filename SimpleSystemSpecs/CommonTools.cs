using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;
using NLog.Fluent;

using Microsoft.Extensions.Configuration;
namespace SimpleSystemSpecs
{
   public class CommonTools
    {
        public static Logger logger;//= LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        public static void CreateLogger()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    //.SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                var tlogger = LogManager.Setup()
                       .LoadConfigurationFromSection(config)
                       .GetCurrentClassLogger();

                logger = tlogger;
            }
            catch (Exception ex)
            {
                ErrorReporting(ex);


            }

        }

        public static void ErrorReporting(Exception ex)
        {
            //throw (ex);
            //SlimeWeb.Core.Configuration.SlimeWeb.CoreSettingManager conf = new Configuration.SlimeWeb.CoreSettingManager();
            if (ex.GetBaseException() is ValidationException)
            {
                // ValidationErrorReporting((ValidationException)ex);
                logger.Fatal(ex);

            }
            else
            {


                CreateLogger();


                //(new CompactJsonFormatter());



                //.ReadFrom.Services(services)
                //  .Enrich.FromLogContext()

                // .WriteTo.File(new CompactJsonFormatter(), "/wwwroot/AppData/logs/logs.json"))
                //.CreateBootstrapLogger())

                logger.Fatal(ex.ToString());
                NLog.LogManager.Flush();
                // logger.Fatal(ex);
                // if (conf.ExceptionShownOnBrowser() == true)
                //  {
                //  Console.WriteLine(ex.ToString());
                //throw (ex);
                //   logger.TraceException(ex.Message, ex);
                //  }
            }

        }
    }
}
