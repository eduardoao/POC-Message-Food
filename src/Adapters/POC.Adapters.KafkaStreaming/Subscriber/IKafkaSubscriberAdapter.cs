using Confluent.Kafka;

namespace POC.Adapters.KafkaStreaming.Subscriber
{

    public interface IKafkaSubscriberAdapterTopic
    {
        public void Subscribe(string topic);
    }
}
