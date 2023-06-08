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

        public List<Domain.Storage> GetList()
        {
            var result = _storageRepository.GetList();
            return result;
        }
        public Domain.Storage GetById(int id)
        {
            var result = _storageRepository.GetById(id);
            return result;
        }
        public void DeleteById(int id)
        {
            _storageRepository.DeleteById(id);
        }
        public void Update(Domain.Storage s)
        {
            _storageRepository.Update(s);
        }
        public Domain.Storage Insert(Domain.Storage s)
        {
            var result = _storageRepository.Insert(s);
            return result;
        }
    }
}
