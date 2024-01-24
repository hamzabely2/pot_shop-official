﻿using Context.Interface;
using Ioc.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Test.Common
{
    public class TestBase
    {
        protected ServiceProvider _serviceProvider;

        protected PotShopIDbContext _context;
        private readonly IConfiguration _configuration;


        private void InitTestDatabase()
        {
            _context = _serviceProvider.GetService<PotShopIDbContext>();
            _context?.Database.EnsureDeleted();
            _context?.Database.EnsureCreated();
        }

        public void SetUpTest()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .ConfigureDBContextTest()
                .ConfigureInjectionDependencyRepositoryTest()
                .BuildServiceProvider();

            InitTestDatabase();
        }

        public void CleanTest()
        {
            _context?.Database.EnsureDeleted();
            _serviceProvider.Dispose();
            _context?.Dispose();
        }

        public JwtSecurityToken GenerateJwtTokenForUser(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return token;

        }
    }
}
