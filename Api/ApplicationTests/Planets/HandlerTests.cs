using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistence;
using AutoMapper;
using Application.Core;
using Application.Planets;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Core.Dtos;
using ApplicationTests.Helper;
using Moq;

namespace ApplicationTests.Planets
{


    [TestClass()]
    public class HandlerTests
    {
        private Mock<DataContext> _contextMock;
        private Mock<DbSet<Planet>> _fakeDbSet;
        private IMapper _mapper;

        public HandlerTests()
        {
            
            _contextMock = new Mock<DataContext>();

            // _contextMock = A.Fake<DataContext>();
            _fakeDbSet = new Mock<DbSet<Planet>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [TestMethod()]
        public async Task HandleTest()
        {
            //arrange 
            IQueryable<PlanetResponse> fakeIQueryable = new List<PlanetResponse>().AsQueryable();
            
           

            var query = new List.Query
            {
                Params = new PagingParams
                {
                    PageNumber = 1,
                    PageSize = 2
                }
            };

            var handler = new List.Handler(_contextMock.Object, _mapper);

            // act

            var result =  await handler.Handle(query, default);

            // Assert
            
            Assert.Equals(result.Value.Count, 2);
        }
    }
}