using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application.Repositories
{
    public class ProductFilterRepository : IProductFilterRepository
    {
        private readonly string _connectionString;
        public ProductFilterRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StorageDB");
        }

        public List<ProductFilter> GetList()
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var products = connection.Query<ProductFilter>("select * from Product where NameOfProduct like 'c%' and Cost>10")
                                         .ToList();
                return products;
            }
        }
        //public ProductFilter Insert(ProductFilter productFilter)
        //{
        //    using var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
        //    var sql = "select * from Product where NameOfProduct like 'c%' and Cost>10";
        //    var rowsAffected = connection.Execute(sql, productFilter);
        //    return productFilter;
        //}
    }
}
