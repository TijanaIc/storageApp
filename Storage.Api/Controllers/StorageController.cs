using Microsoft.AspNetCore.Mvc;
using Storage.Domain;
using Storage.Domain.Repositories;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageRepository _storageRepository;

        public StorageController(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        [HttpGet("list")]
        public List<Domain.Storage> Get()
        {
            var storages = _storageRepository.GetList();
            return storages;
        }

        [HttpGet("search-by-id/{id}")]
        public Domain.Storage GetById(int id)
        {
            var storages = _storageRepository.GetById(id);
            return storages;
        }

        [HttpDelete("delete-by-id/{id}")]
        public void DeleteById(int id)
        {
            _storageRepository.DeleteById(id);
        }
    }
}
