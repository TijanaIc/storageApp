using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application
{
    public class MockStorageRepository : IStorageRepository
    {
        public MockStorageRepository()
        {

        }
        public List<Storages> GetStorages()
        {
            var storages = new List<Storages>();
            return storages;
        }
    }
}
