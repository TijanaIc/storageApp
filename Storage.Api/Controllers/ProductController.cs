using Microsoft.AspNetCore.Mvc;
using Storage.Domain;
using Storage.Domain.BusnessLayer;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("list")]
        public List<Product> Get()
        {
            var products = _productService.GetList();
            return products;
        }

        [HttpGet("search-by-id/{id}")]
        public Product GetById(int id)
        {
            var products = _productService.GetById(id);
            return products;
        }

        [HttpDelete("delete-by-id/{id}")]
        public void Delete(int id)
        {
            _productService.DeleteById(id);
        }

        [HttpPut("update")]
        public void Update(Product p)
        {
            _productService.Update(p);
        }

        [HttpPost("insert")]
        public Product Insert(Product p)
        {
            var products = _productService.Insert(p);
            return products;
        }

        [HttpPost("search")]
        public List<Product> SearchProducts(ProductFilter filter)
        {
            var products = _productService.Search(filter);
            return products;
        }
    }
}
