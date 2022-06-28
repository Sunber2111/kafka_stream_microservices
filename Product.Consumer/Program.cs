using Confluent.Kafka;
using Product.Consumer;


// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

var clientConfig = new ClientConfig()
{
	BootstrapServers = builder.Configuration["Kafka:ClientConfigs:BootstrapServers"]
};

var consumerConfig = new ConsumerConfig(clientConfig)
{
	GroupId = "SourceApp",
	EnableAutoCommit = true,
	AutoOffsetReset = AutoOffsetReset.Earliest,
	StatisticsIntervalMs = 5000,
	SessionTimeoutMs = 6000
};

builder.Services.AddSingleton(consumerConfig);

builder.Services.AddHostedService<ProductOrderConsumer>();

// Configure the HTTP request pipeline.

var app = builder.Build();

app.Run();
