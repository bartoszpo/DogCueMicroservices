using DogCueMicroservices;
using DogCueMicroservices.DBContexts;
using DogCueMicroservices.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using Xunit;

namespace DogCueMicroservicesXT
{
    public class UnitTestControllers
    {
        private readonly WebApplicationFactory<DogCueMicroservices.Startup> _factory;

        private TestServer _server;
        private HttpClient _client;

        public UnitTestControllers()
        {
            // Arrange
            

            //DogCueDBEntities db = new DogCueDBEntities(o => o.UseSqlServer(""));
        }

        [Fact]
        public async void Test1()
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                
                .AddJsonFile("appsettings.json")
                .Build();
            _server = new TestServer(new WebHostBuilder().UseConfiguration(configuration)
               .UseStartup<Startup>());
            _client = _server.CreateClient();

            var response = await _client.GetAsync("/api/Contact");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            try
            {
                var contact = JsonConvert.DeserializeObject<Contact[]>(responseString);
                Assert.Equal("1", contact[0].Customer.ToString());
            }
            catch (Exception e){
                Assert.True(false, "message");
            }

            

        }
    }
}
