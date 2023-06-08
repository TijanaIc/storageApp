using Microsoft.AspNetCore.Mvc;
using Storage.Domain.BusnessLayer;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("list")]
        public List<Domain.Storage> Get()
        {
            var storages = _storageService.GetList();
            return storages;
        }

        [HttpGet("search-by-id/{id}")]
        public Domain.Storage GetById(int id)
        {
            var storages = _storageService.GetById(id);
            return storages;
        }

        [HttpDelete("delete-by-id/{id}")]
        public void DeleteById(int id)
        {
            _storageService.DeleteById(id);
        }

        [HttpPut("update")]
        public void Update(Domain.Storage s)
        {
            _storageService.Update(s);
        }

        [HttpPost("insert")]
        public Domain.Storage Insert(Domain.Storage s)
        {
            var storages = _storageService.Insert(s);
            return storages;
        }
    }
}
