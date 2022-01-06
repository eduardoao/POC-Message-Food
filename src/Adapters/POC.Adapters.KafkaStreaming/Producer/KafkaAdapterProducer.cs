using Confluent.Kafka;
using POC.Modules.InputPorts.Order;
using System.Text.Json;

namespace POC.Adapters.KafkaStreaming.Producer
{
    public class KafkaAdapterProducer : IKafkaAdapter
    {
        public void Produce(object data)
        {
            var config = new ProducerConfig { BootstrapServers = "127.0.0.1:9092" };
            using var p = new ProducerBuilder<Null, string>(config).Build();
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                     var lineName = (PlaceOrderItentInput)data;
                   
                      var dr = p.ProduceAsync(lineName.OrderProductItem.EAreas.ToString(),
                      new Message<Null, string>
                      {
                         Value = JsonSerializer.Serialize(lineName, options)
                      });
                      p.Flush();
                }
                catch (ProduceException<Null, string> e)
                {                    
                    _ = e.Error.Reason;
                }
            }
        }
    }
}
