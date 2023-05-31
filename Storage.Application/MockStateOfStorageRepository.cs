using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Application
{
    public class MockStateOfStorageRepository : IStateOfStorageRepository
    {
        public MockStateOfStorageRepository()
        {

        }
        public List<StateOfStorage> GetList()
        {
            var st1 = new StateOfStorage();
            st1.StateOfStorageId = 1;
            st1.ProductId = 1;
            st1.StorageId = 1;
            st1.Quantity = 1;
            var st2 = new StateOfStorage();
            st2.StateOfStorageId = 2;
            st2.ProductId = 2;
            st2.StorageId = 2;
            st2.Quantity = 2;
            var stateOfStorages = new List<StateOfStorage>();
            stateOfStorages.Add(st1);
            stateOfStorages.Add(st2);
            return stateOfStorages;
        }

        public StateOfStorage GetById(int id)
        {
            var st = new StateOfStorage();
            st.StateOfStorageId = 1;
            return st;
        }

        public void DeleteById(int id)
        {

        }
    }
}
