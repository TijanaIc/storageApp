using Storage.Domain;
using Storage.Domain.BusnessLayer;
using Storage.Domain.Repositories;

namespace Storage.Application.BusinessLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetList()
        {
            var result = _productRepository.GetList();
            return result;
        }
        public Product GetById(int id)
        {
            var result = _productRepository.GetById(id);
            return result;
        }
        public void DeleteById(int id)
        {
            _productRepository.DeleteById(id);
        }
        public void Update(Product p)
        {
            _productRepository.Update(p);
        }
        public Product Insert(Product p)
        {
            var result = _productRepository.Insert(p);
            return result;
        }
        public List<Product> Search(ProductFilter filter)
        {
            var products = _productRepository.GetList(filter);
            return products;
        }
    }
}
