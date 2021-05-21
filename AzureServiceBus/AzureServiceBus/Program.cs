using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Azure service bus");

            string connectionString = "Endpoint=sb://test-servicebus-irentaa.servicebus.windows.net/;SharedAccessKeyName=writeToQueeu;SharedAccessKey=cJ2jUzoD67rxk6y6BkM8RRCPJdKXeH8mgWzd9NlxLQk=";
            string queueName = "testqueue";

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            Person dinith = new Person
            {
                NIC = "953280086",
                Name = "dinith jayabodhi",
                Age = 26
            };

            MessagePublisher publisher = new MessagePublisher(queueClient);

            //Task.Run(() => publisher.PublisStringMessage($"hii from dj at {DateTime.Now} "));
            Task.Run(() => publisher.PublishPersonInfo(dinith));

            Console.WriteLine("message has been sent");
            //publisher.PublisStringMessage("");

            Console.ReadLine();
        }
    }
}
