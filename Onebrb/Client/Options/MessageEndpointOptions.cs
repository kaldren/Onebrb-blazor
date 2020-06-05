using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Client.Options
{
    public class MessageEndpointOptions
    {
        public const string ApiMessagesEndpoint = "ApiMessagesEndpoint";

        public string CreateMessage { get; set; }
        public string GetOneMessage { get; set; }
        public string GetAllMessages { get; set; }
    }
}
