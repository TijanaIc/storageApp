using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage.Domain.Repositories;
using Storage.Domain;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateOfStorageController : ControllerBase
    {
        private readonly IStateOfStorageRepository _stateOfStorageRepository;

        public StateOfStorageController(IStateOfStorageRepository stateOfStorageRepository)
        {
            _stateOfStorageRepository = stateOfStorageRepository;
        }

        [HttpGet("list")]
        public List<StateOfStorage> Get()
        {
            var stateOfStorages = _stateOfStorageRepository.GetList();
            return stateOfStorages;
        }

        [HttpGet("search-by-id/{id}")]
        public StateOfStorage GetById(int id)
        {
            var stateOfStorages = _stateOfStorageRepository.GetById(id);
            return stateOfStorages;
        }
    }
}
