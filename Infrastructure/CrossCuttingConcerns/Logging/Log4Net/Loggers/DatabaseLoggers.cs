using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLoggers : LoggerServiceBase
    {
        public DatabaseLoggers() : base("DatabaseLogger")
        {

        }
    }
}
