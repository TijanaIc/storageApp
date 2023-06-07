using Microsoft.AspNetCore.Mvc;
using Storage.Domain.Repositories;
using Storage.Domain;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFilterController : ControllerBase
    {
        private readonly IProductFilterRepository _productFilterRepository;

        public ProductFilterController(IProductFilterRepository productFilterRepository)
        {
            _productFilterRepository = productFilterRepository;
        }

        [HttpGet("list")]
        public List<ProductFilter> Get()
        {
            var products = _productFilterRepository.GetList();
            return products;
        }

        //[HttpPost("insert")]
        //public ProductFilter Insert(ProductFilter p)
        //{
        //    var products = _productFilterRepository.Insert(p);
        //    return products;
        //}
    }
}
