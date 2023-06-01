namespace Storage.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetList();
        Product GetById(int id);
        void DeleteById(int id);        
        void Update(Product p);
        Product Insert(Product p);
    }
}
