using AutoFixture;
using Medication.Api.Contracts;
using Medication.Api.Controllers;
using Medication.Api.Repositories;
using Medication.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Medication.Tests
{
    public class GetTests
    {
        private Mock<MedicationRequestRepository> repositoryMock;
        private Fixture fixture;

        public GetTests()
        {
            repositoryMock = new Mock<MedicationRequestRepository>();
            fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Get_All_ReturnsOk()
        {
            var samples = 10;
            var requestList = fixture.CreateMany<MedicationRequest>(samples).ToList();
            repositoryMock.Setup(x => x.GetAsync(null, null, null)).ReturnsAsync(requestList);

            var controller = new MedicationRequestController(null, repositoryMock.Object);

            var result = await controller.Get(null, null, null);
            var objectResult = result as ObjectResult;
            var resultList = objectResult?.Value as IList<GetMedicationRequest>;

            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal(samples, resultList?.Count);
        }
    }
}
