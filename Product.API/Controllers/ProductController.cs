using EventBus.EventsName;
using EventBus.Kafka.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core.DTO.Products;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IKafkaProducer<ProductViewModel> _producer;

        public ProductController(IKafkaProducer<ProductViewModel> producer)
        {
            _producer = producer;
        }

        [HttpGet]
        public async Task CreateOrder()
        {
            await _producer.ProduceAsync(AppEvents.OrderedProducts, new ProductViewModel());
        }
    }
}
