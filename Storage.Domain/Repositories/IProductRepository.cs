using System.Numerics;

namespace Storage.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetList();
        Product GetById(int id);
        void DeleteById(int id);
        //void Insert(Product p);
        void Update(Product p);
    }
}
