using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application
{
    public class MockStateOfStorageRepository : IStateOfStorageRepository
    {
        public MockStateOfStorageRepository()
        {

        }
        public List<StateOfStorage> GetStatesOfStorages()
        {
            var stateOfStorages = new List<StateOfStorage>();
            return stateOfStorages;
        }
    }
}
