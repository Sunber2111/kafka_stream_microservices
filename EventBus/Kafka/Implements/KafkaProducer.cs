using Confluent.Kafka;
using EventBus.EventsName;
using EventBus.Kafka.Helper;
using EventBus.Kafka.Interfaces;
using System.ComponentModel;

namespace EventBus.Kafka.Implements
{
    public class KafkaProducer<TValue> : IDisposable, IKafkaProducer<TValue> where TValue : class
    {
        private readonly IProducer<string, TValue> _producer;

        public KafkaProducer(ProducerConfig config)
        {
            _producer = new ProducerBuilder<string, TValue>(config).SetValueSerializer(new KafkaSerializer<TValue>()).Build();
        }

        public void Dispose()
        {
            _producer.Flush();
            _producer.Dispose();
        }

        public async Task ProduceAsync(AppEvents topic, string key, TValue value)
        {
            // Local Func
            string GetDescriptionFromEnumValue(Enum value)
            {
                DescriptionAttribute attribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }

            await _producer.ProduceAsync(GetDescriptionFromEnumValue(topic), new Message<string, TValue> { Key = key, Value = value });
        }

        public async Task ProduceAsync(AppEvents topic, TValue value)
        {
            await _producer.ProduceAsync(topic.ToString(), new Message<string, TValue> { Key = "", Value = value });
        }
    }
}
