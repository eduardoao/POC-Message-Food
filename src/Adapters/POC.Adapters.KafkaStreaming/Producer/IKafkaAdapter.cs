﻿namespace POC.Adapters.KafkaStreaming.Producer
{
    public interface IKafkaAdapter
    {
        public void Produce(object data);
    }
}
