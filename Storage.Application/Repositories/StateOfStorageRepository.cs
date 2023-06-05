using Dapper;
using Microsoft.Extensions.Configuration;
using Storage.Domain;
using Storage.Domain.Repositories;

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
            var sqlDeleteStateOfStorage = $"delete from dbo.StateOfStorage where StateOfStorageId = {id}";

            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Execute(sqlDeleteStateOfStorage);
            }
        }
        public void Update(StateOfStorage stateOfStorage)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var sql = $"update dbo.StateOfStorage set ProductId = @ProductId, StorageId = @StorageId, Quantity = @Quantity where StateOfStorageId = @StateOfStorageId";
                var rowsAffected = connection.Execute(sql, stateOfStorage);
            }
        }
        public StateOfStorage Insert(StateOfStorage stateOfStorage)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_connectionString))
            {
                var sqlInsertStateOfStorage = "insert into dbo.StateOfStorage (ProductId, StorageId, Quantity) values (@ProductId, @StorageId, @Quantity)";
                var rowsAffected = connection.Execute(sqlInsertStateOfStorage, stateOfStorage);
                return stateOfStorage;
            }
        }        
    }
}
