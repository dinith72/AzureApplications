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
            string msgString = JsonSerializer.Serialize(person);
          
            Console.WriteLine(msgString);
            try
            {
                var msgObj = new Message(Encoding.UTF8.GetBytes(msgString));
                await _queueclient.SendAsync(msgObj);
                Console.WriteLine("message has been sent");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
