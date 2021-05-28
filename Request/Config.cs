using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request
{
    public class Config
    {
        public string serviceBusConnectionStringSender { get; set; }
        public string serviceBusQueueName { get; set; }
    }
}
