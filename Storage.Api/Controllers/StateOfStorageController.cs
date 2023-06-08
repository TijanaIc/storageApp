using Microsoft.AspNetCore.Mvc;
using Storage.Domain;
using Storage.Domain.BusnessLayer;

namespace Storage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateOfStorageController : ControllerBase
    {
        private readonly IStateOfStorageService _stateOfStorageService;

        public StateOfStorageController(IStateOfStorageService stateOfStorageService)
        {
            _stateOfStorageService = stateOfStorageService;
        }

        [HttpGet("list")]
        public List<StateOfStorage> Get()
        {
            var stateOfStorages = _stateOfStorageService.GetList();
            return stateOfStorages;
        }

        [HttpGet("search-by-id/{id}")]
        public StateOfStorage GetById(int id)
        {
            var stateOfStorages = _stateOfStorageService.GetById(id);
            return stateOfStorages;
        }

        [HttpDelete("delete-by-id/{id}")]
        public void DeleteById(int id)
        {
            _stateOfStorageService.DeleteId(id);
        }

        [HttpPut("update")]
        public void Update(StateOfStorage st)
        {
            _stateOfStorageService.Update(st);
        }

        [HttpPost("insert")]
        public StateOfStorage Insert(StateOfStorage st)
        {
            var stateOfStorages = _stateOfStorageService.Insert(st);
            return stateOfStorages;
        }
    }
}
