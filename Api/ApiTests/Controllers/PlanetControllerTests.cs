using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using Application.Core.Dtos;
using MediatR;
using static Application.Planets.List;
using Application.Core;
using System.ComponentModel;

namespace Api.Controllers.Tests
{
    [TestClass()]
    public class PlanetControllerTests
    {
        [TestMethod()]
        public void ListTest()
        {
            // arrange 
            var query = A.Dummy<Query>();

            var fakePlanets = A.CollectionOfDummy<Result<PagedList<PlanetResponse>>>(5).AsEnumerable();
            
            var fakeMediator = A.Fake<IMediator>();
            A.CallTo(() => fakeMediator.Send(A<Application.Planets.List.Handler>.))
            var  controller = new PlanetController();

            //act


            // assert
            Assert.Fail();
        }
    }
}