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
        private readonly ILogger<StateOfStorageController> _logger;

        public StateOfStorageController(IStateOfStorageRepository stateOfStorageRepository, ILogger<StateOfStorageController> logger)
        {
            _stateOfStorageRepository = stateOfStorageRepository;
            _logger = logger;
        }

        [HttpGet("list")]
        public List<StateOfStorage> Get()
        {
            var stateOfStorages = _stateOfStorageRepository.GetStatesOfStorages();
            return stateOfStorages;
        }
    }
}
