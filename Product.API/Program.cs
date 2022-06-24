using Confluent.Kafka;
using EventBus.Kafka.Implements;
using EventBus.Kafka.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var clientConfig = new ClientConfig()
{
	BootstrapServers = builder.Configuration["Kafka:ClientConfigs:BootstrapServers"]
};

var producerConfig = new ProducerConfig(clientConfig);

builder.Services.AddSingleton(producerConfig);

builder.Services.AddControllers();

builder.Services.AddSingleton(typeof(IKafkaProducer<>), typeof(KafkaProducer<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
