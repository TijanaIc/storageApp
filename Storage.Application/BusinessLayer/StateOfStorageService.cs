using Storage.Domain;
using Storage.Domain.BusnessLayer;
using Storage.Domain.Repositories;

namespace Storage.Application.BusinessLayer
{
    public class StateOfStorageService : IStateOfStorageService
    {
        private readonly IStateOfStorageRepository _stateOfStorageRepository;

        public StateOfStorageService(IStateOfStorageRepository stateOfStorageRepository)
        {
            _stateOfStorageRepository = stateOfStorageRepository;
        }

        public List<StateOfStorage> GetStateOfStorageList()
        {
            var result = _stateOfStorageRepository.GetList();
            return result;
        }
        public StateOfStorage GetStateOfStorageById(int id)
        {
            var result = _stateOfStorageRepository.GetById(id);
            return result;
        }
        public void DeleteStateOfStorageById(int id)
        {
            _stateOfStorageRepository.DeleteById(id);
        }
        public void UpdateStateOfStorage(StateOfStorage st)
        {
            _stateOfStorageRepository.Update(st);
        }
        public StateOfStorage InsertStateOfStorage(StateOfStorage st)
        {
            var result = _stateOfStorageRepository.Insert(st);
            return result;
        }
    }
}
