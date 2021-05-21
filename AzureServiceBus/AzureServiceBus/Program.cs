using Microsoft.Azure.ServiceBus;
using System;
using System.Configuration;
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

            string connectionString = ConfigurationManager.AppSettings.Get("AzureStorageBus");
            string queueName = ConfigurationManager.AppSettings.Get("QueueName");
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            Person dinith = new Person
            {
                NIC = "953280086",
                Name = "dinith jayabodhi_final",
                Age = 26
            };

            MessagePublisher publisher = new MessagePublisher(queueClient);

            //Task.Run(() => publisher.PublisStringMessage($"hii from dj at {DateTime.Now} "));
            Task.Run(() => publisher.PublishPersonInfo(dinith));

            
            //publisher.PublisStringMessage("");

            Console.ReadLine();
        }
    }
}
