using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application
{
    public class MockProductRepository : IProductRepository
    {
        public MockProductRepository()
        {

        }
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            return products;
        }
    }
}
