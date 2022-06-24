using Confluent.Kafka;
using EventBus.EventsName;
using EventBus.Kafka.Helper;
using Newtonsoft.Json;
using Product.Core.DTO.Products;

namespace Product.Consumer
{
    public class ProductOrderConsumer : BackgroundService
    {
        private readonly IConsumer<string, ProductViewModel> _consumer;
        private readonly ILogger<ProductOrderConsumer> _logger;

        public ProductOrderConsumer(ConsumerConfig config, ILogger<ProductOrderConsumer> logger)
        {
            _consumer = new ConsumerBuilder<string, ProductViewModel>(config).SetValueDeserializer(new KafkaDeserializer<ProductViewModel>()).Build();
            _consumer.Subscribe(AppEvents.OrderedProducts.ToString());
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = _consumer.Consume(stoppingToken);

                if (result != null)
                {
                    _logger.LogInformation("Recived Message : "+ JsonConvert.SerializeObject(result.Message.Value));
                }               

            }

            return Task.CompletedTask;
        }
    }
}
