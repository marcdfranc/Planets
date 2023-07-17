using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCliente.Factories;
using RandomTestValues;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace XCliente.Tests
{
    [TestClass()]
    public class PlanetClientTests
    {
        private string _baseUrl;
        private string _apiKey;

        public PlanetClientTests()
        {
            _baseUrl = "http://localhost:5188";
            _apiKey = "9Ap2QwHNJzv8nBJV";
        }

        [TestMethod()]
        public async Task CreatePlanetEndPointTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            bool created = false;
            // act
            try
            {
                await planetClient.CreatePlanetAsync(planet);
                created = true;
            }
            catch (ApiException) { }

            //Assert
            Assert.IsTrue(created);
        }

        [TestMethod()]
        public async Task ValidNameLenghtOnCreateTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Position = -1;            
            int statusCode = StatusCodes.Status200OK;            
            // act
            try
            {
                await planetClient.CreatePlanetAsync(planet);                
            }
            catch (ApiException e) {
                statusCode = e.StatusCode;
            }

            //Assert
           Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);            
        }

        [TestMethod()]
        public async Task ValidNameRequiredOnCreateTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = null;
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            // act
            try
            {
                await planetClient.CreatePlanetAsync(planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task ImagePathRequiredOnCreateTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.ImagePath = null;
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            // act
            try
            {
                await planetClient.CreatePlanetAsync(planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task ImageIconPathRequiredOnCreateTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.ImageIconPath = null;
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            // act
            try
            {
                await planetClient.CreatePlanetAsync(planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task PaginationOnHeaderOnGetTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            // act
            try
            {
               var planets = await planetClient.GetPlanetsAsync();
            }
            catch (ApiException ) { }

            //Assert
            Assert.IsNotNull(planetClient.Pagination);
        }

        [TestMethod()]
        public async Task PaginationSelectPageAndSizeOnGetTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            int pageNamber = 2;
            int pageSize = 3;
            List<PlanetResponse> planets = null!;
            // act
            try
            {
                planets = await planetClient.GetPlanetsAsync(pageNamber, pageSize);
            }
            catch (ApiException) { }

            //Assert
            Assert.IsTrue(planets?.Count == pageSize && planetClient.Pagination.CurrentPage == pageNamber);
        }


        [TestMethod()]
        public async Task DetailPLanetTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);            
            int statusCode = StatusCodes.Status200OK;
            try
            {
                var planets = await planetClient.GetPlanetsAsync();
                // act
                var planet = await planetClient.DetailPlanetAsync(planets.FirstOrDefault()!.Id);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status200OK);
        }

        [TestMethod()]
        public async Task NotFoundDetailPLanetTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            int statusCode = StatusCodes.Status200OK;
            // act
            try
            {                
                var planet = await planetClient.DetailPlanetAsync(Guid.NewGuid());
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status404NotFound);
        }

        [TestMethod()]
        public async Task EditPlanetEndPointTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            bool edited = false;
            
            try
            {
                await planetClient.CreatePlanetAsync(planet);

                var planets = await planetClient.GetPlanetsAsync(1, 100);
                var planetId = planets.FirstOrDefault(p => p.Position < 0)!.Id;

                planet.Name = "Something";

                // act
                await planetClient.EditPlanetAsync(planetId, planet);
                edited = true;
            }
            catch (ApiException) { }

            //Assert
            Assert.IsTrue(edited);
        }

        [TestMethod()]
        public async Task EditPlanetNotFoundTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;           
            try
            {               
                // act
                await planetClient.EditPlanetAsync(Guid.NewGuid(), planet);                
            }
            catch (ApiException e) {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status404NotFound);
        }

        [TestMethod()]
        public async Task ValidNameLenghtOnEditTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            try
            {
                await planetClient.CreatePlanetAsync(planet);

                var planets = await planetClient.GetPlanetsAsync(1, 100);
                var planetId = planets.FirstOrDefault(p => p.Position < 0)!.Id;

                planet.Name = "Something biggger than 30 characters";

            // act
                await planetClient.EditPlanetAsync(planetId, planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task ValidNameRequiredOnEditTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            try
            {
                await planetClient.CreatePlanetAsync(planet);
                var planets = await planetClient.GetPlanetsAsync(1, 100);
                var planetId = planets.FirstOrDefault(p => p.Position < 0)!.Id;
                planet.Name = null; 
                
                // act
                await planetClient.EditPlanetAsync(planetId, planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task ImagePathRequiredOnEditTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            try
            {
                await planetClient.CreatePlanetAsync(planet);
                var planets = await planetClient.GetPlanetsAsync(1, 100);
                var planetId = planets.FirstOrDefault(p => p.Position < 0)!.Id;
                planet.ImagePath = null;

                // act
                await planetClient.CreatePlanetAsync(planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task ImageIconPathRequiredOnEditTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            try
            {
                await planetClient.CreatePlanetAsync(planet);
                var planets = await planetClient.GetPlanetsAsync(1, 100);
                var planetId = planets.FirstOrDefault(p => p.Position < 0)!.Id;
                planet.ImageIconPath = null;

                // act
                await planetClient.CreatePlanetAsync(planet);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        [TestMethod()]
        public async Task DeleteEndpointTestTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);
            var planet = RandomValue.Object<PlanetData>();
            planet.Name = planet.Name.Substring(0, new Random().Next(29));            
            planet.Position = -1;
            int statusCode = StatusCodes.Status200OK;
            try
            {
                await planetClient.CreatePlanetAsync(planet);
                var planets = await planetClient.GetPlanetsAsync(1, 100);
                var planetId = planets.FirstOrDefault(p => p.Position < 0)!.Id;
                
                // act
                await planetClient.DeletePlanetAsync(planetId);
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }

            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status200OK);
        }

        [TestMethod()]
        public async Task DeleteEndpointNotFoundTest()
        {
            // Arrange
            var planetClient = ServiceFactory.GetAnonymousClient<PlanetClient>(_baseUrl, _apiKey);           
            int statusCode = StatusCodes.Status200OK;
            // act
            try
            {
                await planetClient.DeletePlanetAsync(Guid.NewGuid());
            }
            catch (ApiException e)
            {
                statusCode = e.StatusCode;
            }
            //Assert
            Assert.AreEqual(statusCode, StatusCodes.Status404NotFound);
        }

    }
}