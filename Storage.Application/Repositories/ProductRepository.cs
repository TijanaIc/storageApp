using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StorageDB");
        }
        public List<Product> GetList()
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var products = connection.Query<Product>("select * from dbo.Product")
                                         .ToList();
                return products;
            }
        }
        public Product GetById(int id)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var product = connection.QuerySingleOrDefault<Product>($"select * from dbo.Product where ProductId = '{id}'");
                return product;
            }
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        public Product Insert(Product p)
        {
            throw new NotImplementedException();
        }
        public void Update(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
