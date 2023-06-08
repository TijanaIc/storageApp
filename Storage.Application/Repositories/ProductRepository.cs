using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain;
using Storage.Domain.Repositories;
using System.Data;
using System.Data.SqlClient;

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
            using (var connection = new SqlConnection(_connectionString))
            {
                var products = connection.Query<Product>("select * from dbo.Product")
                                         .ToList();
                return products;
            }
        }
        public Product GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var product = connection.QuerySingleOrDefault<Product>($"select * from dbo.Product where ProductId = {id}");
            return product;
        }

        public List<Product> GetList(ProductFilter filter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var products = connection.Query<Product>($"select * from Product where NameOfProduct like '{filter.NameOfProduct}%' and Cost>{filter.Cost}")
                                         .ToList();
                return products;
            }
        }
        public void DeleteById(int id)
        {
            var sqlDeleteStateOfStorage = "delete from dbo.StateOfStorage where ProductId = @ProductId";
            var sqlDeleteProduct = "delete from dbo.Product where ProductId=@ProductId";            
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command;
            using var transaction = connection.BeginTransaction();
            try
            {
                command = new SqlCommand(sqlDeleteStateOfStorage, connection, transaction);
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand(sqlDeleteProduct, connection, transaction);
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }            
        }
        public void Update(Product product)
        {
            var sql = $"update dbo.Product set NameOfProduct = @NameOfProduct, Cost = @Cost where ProductId = @ProductId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var rowsAffected = connection.Execute(sql, product, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public Product Insert(Product product)
        {
            var sql = "insert into dbo.Product (NameOfProduct, Cost) values (@NameOfProduct, @Cost)";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var rowsAffected = connection.Execute(sql, product, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            return product;
        }
    }
}