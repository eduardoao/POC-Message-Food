using Confluent.Kafka;
using System;
using System.Threading;
using System.Text.Json;
using POC.Modules.InputPorts.Order;

namespace POC.Adapters.KafkaStreaming.Subscriber
{
    public sealed class KafkaSubscriberAdapterTopic : IKafkaSubscriberAdapterTopic
    {
        public void Subscribe(string topic)
        {

            var conf = new ConsumerConfig
            {
                GroupId = "order-consumer-group",
                BootstrapServers = "127.0.0.1:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var c = new ConsumerBuilder<Ignore, string>(conf).Build();
            {

                c.Subscribe(topic);

                var cts = new CancellationTokenSource();

                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                var cr = c.Consume(cts.Token);

                try
                {
                    while (true)
                    {
                        try
                        {
                            var options = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = false,
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                            };

                            var data = JsonSerializer.Deserialize<PlaceOrderItentInput>(cr.Message.Value, options);

                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine(
                                $"Order number: { data.OrderId} started process. " +
                                $"Order item product: {data.OrderProductItem.Description} - " +
                                $"Id: {data.OrderProductItem.Id}" +
                                $"Price: {data.OrderProductItem.Price}" +
                                $"Quantity: {data.OrderProductItem.Quantity}" +
                                $"at: '{cr.TopicPartitionOffset}'. " +
                                $"Send to { data.OrderProductItem.EAreas} line");
                            
                            c.Consume();

                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    c.Close();
                }

            }
        }     
    }


}
