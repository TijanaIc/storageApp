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

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("list")]
        public List<Product> Get()
        {
            var products = _productRepository.GetList();
            return products;
        }

        [HttpGet("search-by-id/{id}")]
        public Product GetById(int id)
        {
            var products = _productRepository.GetById(id);
            return products;
        }

        [HttpDelete("delete-by-id/{id}")]
        public void Delete(int id)
        {
            _productRepository.DeleteById(id);
        }

        [HttpPut("update")]
        public void Update(Product p)
        {
            _productRepository.Update(p);
        }

        [HttpPost("insert")]
        public Product Insert(Product p)
        {
            var products = _productRepository.Insert(p);
            return products;
        }
    }
}
