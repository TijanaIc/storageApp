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

        public List<StateOfStorage> GetList()
        {
            var result = _stateOfStorageRepository.GetList();
            return result;
        }
        public StateOfStorage GetById(int id)
        {
            var result = _stateOfStorageRepository.GetById(id);
            return result;
        }
        public void DeleteId(int id)
        {
            _stateOfStorageRepository.DeleteById(id);
        }
        public void Update(StateOfStorage st)
        {
            _stateOfStorageRepository.Update(st);
        }
        public StateOfStorage Insert(StateOfStorage st)
        {
            var result = _stateOfStorageRepository.Insert(st);
            return result;
        }
    }
}
