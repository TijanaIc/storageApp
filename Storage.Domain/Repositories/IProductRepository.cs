using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void DeleteProduct(int productId);
        void InsertProduct(Product p);
        void UpdateProduct(Product p);
    }
}
