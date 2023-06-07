using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

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
            using (var connection = new SqlConnection(_connectionString))
            {
                var storages = connection.Query<Domain.Storage>("select * from dbo.Storage")
                                         .ToList();
                return storages;
            }
        }
        public Domain.Storage GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var storage = connection.QuerySingleOrDefault<Domain.Storage>($"select * from dbo.Storage where StorageId = '{id}'");
                return storage;
            }
        }
        public void DeleteById(int id)
        {
            var sqlDeleteStateOfStorage = $"delete from dbo.StateOfStorage where StorageId = @StorageId";
            var sqlDeleteStorage = $"delete from dbo.Storage where StorageId = @StorageId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command;
            using var transaction = connection.BeginTransaction();
            try
            {
                command = new SqlCommand(sqlDeleteStateOfStorage, connection, transaction);
                command.Parameters.Add("@StorageId", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand(sqlDeleteStorage, connection, transaction);
                command.Parameters.Add("@StorageId", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
        public void Update(Domain.Storage storage)
        {
            var sql = $"update dbo.Storage set NameOfStorage = @NameOfStorage, KindOfStorage = @KindOfStorage where StorageId = @StorageId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var rowsAffected = connection.Execute(sql, storage, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
        public Domain.Storage Insert(Domain.Storage storage)
        {
            var sql = "insert into dbo.Storage (NameOfStorage, KindOfStorage) values (@NameOfStorage, @KindOfStorage)";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var rowsAffected = connection.Execute(sql, storage, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            return storage;
        }        
    }
}
