using Microsoft.AspNetCore.Mvc;
using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository,ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet("list")]
        public List<Product> Get()
        {
            var products = _productRepository.GetProducts();
            return products;
        }
    }
}
