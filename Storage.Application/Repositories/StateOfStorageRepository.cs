using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain;
using Storage.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace Storage.Application.Repositories
{
    public class StateOfStorageRepository : IStateOfStorageRepository
    {
        private readonly string _connectionString;
        public StateOfStorageRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("StorageDB");
        }
        public List<StateOfStorage> GetList()
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var stateOfStorages = connection.Query<StateOfStorage>("select * from dbo.StateOfStorage")
                                         .ToList();
                return stateOfStorages;
            }
        }
        public StateOfStorage GetById(int id)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var stateOfStorage = connection.QuerySingleOrDefault<StateOfStorage>($"select * from dbo.StateOfStorage where StateOfStorageId = '{id}'");
                return stateOfStorage;
            }
        }
        public void DeleteById(int id)
        {
            var sqlDeleteStateOfStorage = $"delete from dbo.StateOfStorage where StateOfStorageId = @StateOfStorageId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command;
            using var transaction = connection.BeginTransaction();
            try
            {
                command = new SqlCommand(sqlDeleteStateOfStorage, connection, transaction);
                command.Parameters.Add("@StateOfStorageId", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
                command.Dispose();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
        public void Update(StateOfStorage stateOfStorage)
        {
            var sql = "update dbo.StateOfStorage set ProductId = @ProductId, StorageId = @StorageId, Quantity = @Quantity where StateOfStorageId = @StateOfStorageId";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var rowsAffected = connection.Execute(sql, stateOfStorage, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
        public StateOfStorage Insert(StateOfStorage stateOfStorage)
        {
            var sqlInsertStateOfStorage = "insert into dbo.StateOfStorage (ProductId, StorageId, Quantity) values (@ProductId, @StorageId, @Quantity)";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var rowsAffected = connection.Execute(sqlInsertStateOfStorage, stateOfStorage, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            return stateOfStorage;
        }        
    }
}
