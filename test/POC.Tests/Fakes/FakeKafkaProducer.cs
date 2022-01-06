using POC.Adapters.KafkaStreaming.Producer;

namespace POC.Tests.Fakes
{
    public class FakeKafkaProducer : IKafkaAdapter
    {
        public void Produce(object data)
        {
        }
    }
}
