using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}
