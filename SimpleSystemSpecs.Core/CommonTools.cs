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
         public static string FormatFilesyzeToCorrectMeasurement(long filesize)
        {
            try
            {
                string ap = "";
                if (filesize >= 0)
                {
                    string sLen = filesize.ToString();
                    if (filesize >= (1 << 30))
                        sLen = string.Format("{0}Gb", filesize >> 30);
                    else
                    if (filesize >= (1 << 20))
                        sLen = string.Format("{0}Mb", filesize >> 20);
                    else
                    if (filesize >= (1 << 10))
                        sLen = string.Format("{0}Kb", filesize >> 10);

                    ap = sLen;
                }

                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


                return "";
            }


        }
    }
}
