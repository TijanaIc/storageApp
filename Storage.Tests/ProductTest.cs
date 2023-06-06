using Microsoft.AspNetCore.Mvc.Testing;
using Storage.Domain;
using System.Net.Http.Json;

namespace Storage.Tests;

public class ProductTest
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProductTest()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task GetProductList_Test()
    {
        var httpClient = _factory.CreateDefaultClient();
        var products = await httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/product/list");
        Assert.NotNull(products);
        Assert.True(10 == products.Count());
    }

    [Fact]
    public async Task GetProductById_Test()
    {
        var httpClient = _factory.CreateDefaultClient();
        var product = await httpClient.GetFromJsonAsync<Product>("/api/product/search-by-id/3");
        Assert.NotNull(product);
        Assert.True(3 == product.ProductId);
    }
}