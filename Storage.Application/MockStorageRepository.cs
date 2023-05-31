using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application
{
    public class MockStorageRepository : IStorageRepository
    {
        public MockStorageRepository()
        {

        }
        public List<Domain.Storage> GetList()
        {
            var storages = new List<Domain.Storage>();
            return storages;
        }
    }
}
