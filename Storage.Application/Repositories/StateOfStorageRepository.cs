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
            throw new NotImplementedException();
        }
        public void Update(StateOfStorage st)
        {
            throw new NotImplementedException();
        }
        public StateOfStorage Insert(StateOfStorage st)
        {
            throw new NotImplementedException();
        }        
    }
}
