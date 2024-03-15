﻿
using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
    public class ColorTest : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        protected readonly PotShopIDbContext _context;

        public ColorTest(WebApplicationFactory<Program> factory)
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
        public async Task GetAllColors_ReturnAllColors()
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
            var response = await _client.GetAsync("/api/color");

            // Assert
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<ColorDto>>>();

            // Vérifiez que la réponse contient la propriété "message" et la propriété "result"
            Assert.NotNull(apiResponse.Message);
            Assert.NotNull(apiResponse.Result);

        }

        [Fact]
        public async Task CreateColor_ReturnColor()
        {

            var newItem = new ColorDto {Id = 5 ,Hex = "ye#00001",Label = "yellow" };
            var newItemJson = new StringContent(JsonSerializer.Serialize(newItem), Encoding.UTF8, "application/json");

            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, "admin_username"),
            new Claim(ClaimTypes.Role, RoleString.Admin)
        }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = await _client.PostAsync("/api/color/create", newItemJson);

            response.EnsureSuccessStatusCode();

            var createdColor = await response.Content.ReadFromJsonAsync<ColorDto>();
            Assert.NotNull(createdColor);
        }

        /* [Fact]
         public async Task DeleteColor_ReturnsNoContent()
         {

             // ID de couleur à supprimer
             int colorId = 1;

             // Créez un utilisateur administrateur simulé avec un jeton d'authentification
             var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
             {
                 new Claim(ClaimTypes.Name, "admin_username"),
                 new Claim(ClaimTypes.Role, RoleString.Admin)
             }, "test"));
             var token = GenerateJwtTokenForUser(adminUser);

             // Configurez le client avec le jeton d'authentification
             _client.DefaultRequestHeaders.Clear();
             _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

             // Act : Supprimez la couleur de l'API
             var response = await _client.DeleteAsync($"/api/color/delete/{colorId}");

             // Assert : Vérifiez que la suppression a réussi avec le statut NoContent (204)
             response.EnsureSuccessStatusCode();
             Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);  
         }*/

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
