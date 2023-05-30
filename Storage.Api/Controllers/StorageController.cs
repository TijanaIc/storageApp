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
        private readonly ILogger<StorageController> _logger;

        public StorageController(IStorageRepository storageRepository, ILogger<StorageController> logger)
        {
            _storageRepository = storageRepository;
            _logger = logger;
        }

        [HttpGet("list")]
        public List<Storages> Get()
        {
            var storages = _storageRepository.GetStorages();
            return storages;
        }
    }
}
