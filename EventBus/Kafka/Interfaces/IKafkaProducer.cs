using EventBus.EventsName;

namespace EventBus.Kafka.Interfaces
{
    public interface IKafkaProducer<TValue> where TValue : class
    {
        Task ProduceAsync(AppEvents topic, string key, TValue value);

        Task ProduceAsync(AppEvents topic, TValue value);
    }
}
