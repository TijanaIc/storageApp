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
            var s1 = new Domain.Storage();
            s1.StorageId = 1;
            s1.NameOfStorage = "test1";
            s1.KindOfStorage = "a";
            var s2 = new Domain.Storage();
            s2.StorageId = 2;
            s2.NameOfStorage = "test2";
            s2.KindOfStorage = "b";
            var storages = new List<Domain.Storage>();
            storages.Add(s1);
            storages.Add(s2);
            return storages;
        }

        public Domain.Storage GetById(int id)
        {
            var s = new Domain.Storage();
            s.StorageId = 1;
            return s;
        }

        public void DeleteById(int id)
        {

        }
    }
}
