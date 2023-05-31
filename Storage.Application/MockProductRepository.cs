using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application
{
    public class MockProductRepository : IProductRepository
    {
        public MockProductRepository()
        {

        }
        public List<Product> GetList()
        {
            var p1 = new Product();
            p1.ProductId = 1;
            p1.NameOfProduct = "Test1";
            p1.Cost = 1;
            var p2 = new Product();
            p2.ProductId = 2;
            p2.NameOfProduct = "Test2";
            p2.Cost = 2;
            var products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            return products;
        }
    }
}
