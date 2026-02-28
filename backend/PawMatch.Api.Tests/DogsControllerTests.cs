using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PawMatch.Api;
using PawMatch.Api.Data;
using PawMatch.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace PawMatch.Api.Tests
{
    public class DogsControllerTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DogsControllerTests(WebApplicationFactory<Program> factory)
        {
            // set environment to trigger in-memory configuration in Program.cs
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing");
            });
        }

        [Fact]
        public async Task PostAndGetDog_Works()
        {
            var client = _factory.CreateClient();

            var newDog = new CreateDogDto { Name = "Fido", Age = 3, Breed = "Labrador" };
            var postResponse = await client.PostAsJsonAsync("/api/dogs", newDog);
            postResponse.EnsureSuccessStatusCode();
            var created = await postResponse.Content.ReadFromJsonAsync<DogDto>();
            Assert.NotNull(created);
            Assert.Equal("Fido", created!.Name);

            var getResponse = await client.GetAsync($"/api/dogs/{created.Id}");
            getResponse.EnsureSuccessStatusCode();
            var fetched = await getResponse.Content.ReadFromJsonAsync<DogDto>();
            Assert.Equal(created.Id, fetched?.Id);
            Assert.Equal(created.Name, fetched?.Name);
        }
    }
}
