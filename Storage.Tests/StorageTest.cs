using Microsoft.AspNetCore.Mvc.Testing;
using Storage.Domain;
using System.Net.Http.Json;

namespace Storage.Tests
{
    public class StorageTest
    {
        private readonly WebApplicationFactory<Program> _factory;

        public StorageTest()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task GetStorageList_Test()
        {
            var httpClient = _factory.CreateDefaultClient();
            var storages = await httpClient.GetFromJsonAsync<IEnumerable<Domain.Storage>>("/api/storage/list");
            Assert.NotNull(storages);
            Assert.True(10 == storages.Count());
        }

        [Fact]
        public async Task GetStoragetById_Test()
        {
            var httpClient = _factory.CreateDefaultClient();
            var storage = await httpClient.GetFromJsonAsync<Domain.Storage>("/api/storage/search-by-id/3");
            Assert.NotNull(storage);
            Assert.True(3 == storage.StorageId);
        }
    }
}
