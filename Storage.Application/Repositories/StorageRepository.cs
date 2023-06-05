using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain;
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
            var sqlDeleteStateOfStorage = $"delete from dbo.StateOfStorage where StorageId = {id}";
            var sqlDeleteStorage = $"delete from dbo.Storage where StorageId={id}";

            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Execute(sqlDeleteStateOfStorage);
                connection.Execute(sqlDeleteStorage);
            }
        }
        public void Update(Domain.Storage storage)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var sql = $"update dbo.Storage set NameOfStorage = @NameOfStorage, KindOfStorage = @KindOfStorage where StorageId = @StorageId";
                var rowsAffected = connection.Execute(sql, storage);
            }
        }
        public Domain.Storage Insert(Domain.Storage storage)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var sql = "insert into dbo.Storage (NameOfStorage, KindOfStorage) values (@NameOfStorage, @KindOfStorage)";
                var rowsAffected = connection.Execute(sql, storage);
                return storage;
            }
        }        
    }
}
