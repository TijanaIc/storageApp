namespace Storage.Domain.BusnessLayer
{
    public interface IProductService
    {
        List<Product> Search(ProductFilter filter);
        List<Product> GetList();
        Product GetById(int id);
        void DeleteById(int id);
        void Update(Product p);
        Product Insert(Product p);
    }
}
