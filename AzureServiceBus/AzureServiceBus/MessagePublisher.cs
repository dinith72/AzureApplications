using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureServiceBus
{
    class MessagePublisher
    {
        public readonly IQueueClient _queueclient;

        public MessagePublisher(IQueueClient queueclient)
        {
            _queueclient = queueclient;
        }

        public async Task PublisStringMessage(string message)
        {
            Console.WriteLine(message);
            try
            {
                var msgObj = new Message(Encoding.UTF8.GetBytes(message));
                await _queueclient.SendAsync(msgObj);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
          
        }

        public async Task PublishPersonInfo(Person person)
        {
            //string msgString = JsonSerializer.Serialize(person);
            string msgString = "{\"Message\":\"{\\\"Code\\\":\\\"TW--TG--REG--REGULATORY\\\",\\\"Path\\\":null,\\\"AlwaysRunOnNewPath\\\":false,\\\"Disabled\\\":false,\\\"Priority\\\":null}\",\"QueueName\":\"CM/Domain/Crawl/SpideringMessages_ScheduleNormal\"}";

            Console.WriteLine(msgString);
            try
            {
                var msgObj = new Message(Encoding.UTF8.GetBytes(msgString));
                await _queueclient.SendAsync(msgObj);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
