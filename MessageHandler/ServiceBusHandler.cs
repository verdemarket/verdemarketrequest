using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using RequestModel;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler
{
    public class ServiceBusHandler
    {
        public async Task<bool> SendToServiceBusQueue(string queue, string connectionString, IRequestModel message)
        {
            try
            {
                var sbClient = new ServiceBusClient(connectionString);
                var sender = sbClient.CreateSender(queue);
                var msg = new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
                await sender.SendMessageAsync(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
