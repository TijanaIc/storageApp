namespace Storage.Domain.BusnessLayer
{
    public interface IProductService
    {
        List<Product> SearchProducts(ProductFilter filter);
        List<Product> GetProductList();
        Product GetProductById(int id);
        void DeleteProductById(int id);
        void UpdateProduct(Product p);
        Product InsertProduct(Product p);
    }
}
