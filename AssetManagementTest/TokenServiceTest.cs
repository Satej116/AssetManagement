using AssetManagement.Interfaces;
using AssetManagement.Models.DTOs;
using AssetManagement.Models.DTOs.Auth;
using AssetManagement.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementTest
{
    public class TokenServiceTest
    {
        private ITokenService _tokenService;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    ["Tokens:JWT"] = "ThisIsAUnitTestSecretKeyForJWTTesting123!"
                })
                .Build();

            _tokenService = new TokenService(config);
        }

        [Test]
        public async Task GenerateToken_ShouldReturnToken_WhenValidUser()
        {
            
            var user = new TokenUserDTO
            {
                Username = "UnitTestUser",
                Role = "Admin"
            };

            var token = await _tokenService.GenerateToken(user);


            Assert.That(token, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GenerateToken_ShouldFail_WhenSecretMissing()
        {
           
            var badConfig = new ConfigurationBuilder().Build();
            var badTokenService = new TokenService(badConfig);

            var user = new TokenUserDTO
            {
                Username = "FailUser",
                Role = "User"
            };
           
            Assert.ThrowsAsync<System.ArgumentException>(() => badTokenService.GenerateToken(user));
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
