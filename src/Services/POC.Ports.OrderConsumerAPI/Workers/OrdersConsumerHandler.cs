using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using POC.Adapters.KafkaStreaming.Subscriber;

namespace POC.Ports.OrderConsumerAPI.Workers
{
    public class OrdersConsumerHandler : IHostedService
    {       
        private readonly IKafkaSubscriberAdapterTopic _kafkaAdapterTopic;
        public OrdersConsumerHandler(
           
            IKafkaSubscriberAdapterTopic kafkaSubscriberAdapterTopic )
        {        
            _kafkaAdapterTopic = kafkaSubscriberAdapterTopic;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var _timer = new Timer(CheckSchedules, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void CheckSchedules(object state)
        {
            Console.WriteLine($"{DateTime.Now:o} => Process consumer orders...");          

            Thread friesStart = new Thread(() => _kafkaAdapterTopic.Subscribe("Fries"));
            Thread grillStart = new Thread(() => _kafkaAdapterTopic.Subscribe("Grill"));
            Thread saladStart = new Thread(() => _kafkaAdapterTopic.Subscribe("Salad"));
            Thread drinkStart = new Thread(() => _kafkaAdapterTopic.Subscribe("Drink"));
            Thread desertStart = new Thread(() => _kafkaAdapterTopic.Subscribe("Desert"));     

            friesStart.Start();
            grillStart.Start();
            saladStart.Start();
            drinkStart.Start();
            desertStart.Start();
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
