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
                var product = connection.QuerySingleOrDefault<Product>($"select * from dbo.Product where ProductId = {id}");
                return product;
            }
        }
        public void DeleteById(int id)
        {
            var sqlDeleteStateOfStorage = $"delete from dbo.StateOfStorage where ProductId = {id}";
            var sqlDeleteProduct = $"delete from dbo.Product where ProductId={id}";
            
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Execute(sqlDeleteStateOfStorage);
                connection.Execute(sqlDeleteProduct);
            }
        }
        public void Update(Product product)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var sql = $"update dbo.Product set NameOfProduct = @NameOfProduct, Cost = @Cost where ProductId = @ProductId";
                var rowsAffected = connection.Execute(sql, product);
            }
        }

        public Product Insert(Product product)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var sql = "insert into dbo.Product (NameOfProduct, Cost) values (@NameOfProduct, @Cost)";
                var rowsAffected = connection.Execute(sql, product);
                return product;
            }
        }
    }
}
