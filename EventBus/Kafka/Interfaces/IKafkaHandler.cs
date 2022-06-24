namespace EventBus.Kafka.Interfaces
{
    public interface IKafkaHandler<TValue>
    {
        Task HandlerAsync(TValue value);
    }
}
