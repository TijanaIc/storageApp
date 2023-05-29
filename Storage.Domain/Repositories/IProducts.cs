using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain.Repositories
{
    public interface IProducts
    {
        List<Products> GetProducts();
        void DeleteProduct(int productId);
        void InsertProduct(Products p);
        void UpdateProduct(Products p);
    }
}
