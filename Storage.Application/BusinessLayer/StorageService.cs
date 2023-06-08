using Storage.Domain.BusnessLayer;
using Storage.Domain.Repositories;

namespace Storage.Application.BusinessLayer
{
    public class StorageService : IStorageService
    {        
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public List<Domain.Storage> GetStorageList()
        {
            var result = _storageRepository.GetList();
            return result;
        }
        public Domain.Storage GetStorageById(int id)
        {
            var result = _storageRepository.GetById(id);
            return result;
        }
        public void DeleteStorageById(int id)
        {
            _storageRepository.DeleteById(id);
        }
        public void UpdateStorage(Domain.Storage s)
        {
            _storageRepository.Update(s);
        }
        public Domain.Storage InsertStorage(Domain.Storage s)
        {
            var result = _storageRepository.Insert(s);
            return result;
        }
    }
}
