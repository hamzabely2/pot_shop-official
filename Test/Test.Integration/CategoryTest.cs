
using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Model.DetailsItem;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Xunit;
using static Test.Common.GenerateToken;

namespace Test.Integration
{
    public class CategoryTest : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        protected readonly PotShopIDbContext _context;

        public CategoryTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Test");
            });

            _context = _factory.Services.GetService<PotShopIDbContext>();

            _client = _factory.CreateClient();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }


        [Fact]
        public async Task GetAllCategories_ReturnAllCategories()
        {

            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin_username"),
                new Claim(ClaimTypes.Role, RoleString.Admin)
            }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            // Act
            var response = await _client.GetAsync("/api/category");

            // Assert
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<CategoryDto>>>();

            // Vérifiez que la réponse contient la propriété "message" et la propriété "result"
            Assert.NotNull(apiResponse.Message);
            Assert.NotNull(apiResponse.Result);

        }

        [Fact]
        public async Task CreateCategorie_ReturnCategorie()
        {

            var newCategory = new CategoryDto { Id=5,  Label = "category_test",Description = "description category_test" };
            var newCategoryJson = new StringContent(JsonSerializer.Serialize(newCategory), Encoding.UTF8, "application/json");

            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin_username"),
                new Claim(ClaimTypes.Role, RoleString.Admin)
            }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = await _client.PostAsync("/api/category/create", newCategoryJson);

            response.EnsureSuccessStatusCode();

            var createdCategory = await response.Content.ReadFromJsonAsync<CategoryDto>();
            Assert.NotNull(createdCategory);
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
