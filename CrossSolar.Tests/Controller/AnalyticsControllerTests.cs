using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Domain;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTests
    {

        public AnalyticsControllerTests()
        {
          _analyticsController = new AnalyticsController(_analyticsRepositoryMock.Object, _panelRepositoryMock.Object);
        }

        private readonly PanelController _panelController;

        private readonly Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();

        private readonly AnalyticsController _analyticsController;

        private readonly Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();
       
        [Fact]
        public async Task Post_InsertsOneHourElectricityFromPanel()
        {
            var oneHourElectricityModel = new OneHourElectricityModel()
            {
                KiloWatt = 23456
            };
            var panelId = "AAAA1111BBBB2222";

            // Arrange

            // Act
            var result = await _analyticsController.Post(panelId,oneHourElectricityModel);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task Get_ReturnsOneDayElectricityFromPanel()
        {
            var panelId = "AAAA1111BBBB2222";
            _analyticsRepositoryMock = anali          
            // Arrange

            // Act
            var result = await _analyticsController.DayResults(panelId);

            // Assert
            Assert.NotNull(result);

            var okResult = result as OkResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_ReturnsOneHourElectricityListFromPanel()
        {
            var panelId = "AAAA1111BBBB2222";

            // Arrange

            // Act
            var result = await _analyticsController.Get(panelId);

            // Assert
            Assert.NotNull(result);

            var okResult = result as OkResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}
