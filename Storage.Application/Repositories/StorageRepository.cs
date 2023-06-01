using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain.Repositories;

namespace Storage.Application.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly string _connectionString;
        public StorageRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StorageDB");
        }
        public List<Domain.Storage> GetList()
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var storages = connection.Query<Domain.Storage>("select * from dbo.Storage")
                                         .ToList();
                return storages;
            }
        }
        public Domain.Storage GetById(int id)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var storage = connection.QuerySingleOrDefault<Domain.Storage>($"select * from dbo.Storage where StorageId = '{id}'");
                return storage;
            }
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Domain.Storage s)
        {
            throw new NotImplementedException();
        }
        public Domain.Storage Insert(Domain.Storage s)
        {
            throw new NotImplementedException();
        }        
    }
}
