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
        public async Task Get_All_ReturnsSuccess()
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

            repositoryMock.VerifyAll();
        }

        private const MedicationRequest.RequestStatus RequestStatus = MedicationRequest.RequestStatus.Active;

        [Fact]
        public async Task Get_ByStatus_ReturnsSuccess()
        {
            var samples = 10;
            var requests = fixture.CreateMany<MedicationRequest>(samples).ToList();
            var statusRequests = requests.Where(x => x.Status == RequestStatus).ToList();
            var statusCount = statusRequests.Count;

            repositoryMock.Setup(x => x.GetAsync(It.IsNotNull<MedicationRequest.RequestStatus>(), null, null)).ReturnsAsync(statusRequests);

            var controller = new MedicationRequestController(null, repositoryMock.Object);

            var result = await controller.Get(RequestStatus, null, null);
            var objectResult = result as ObjectResult;
            var resultList = objectResult?.Value as IList<GetMedicationRequest>;

            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal(statusCount, resultList?.Count);

            repositoryMock.VerifyAll();
        }
        private const int Samples = 10;
        [Fact]
        public async Task Get_ByDate_ReturnsSuccess()
        {
            var requests = fixture.Build<MedicationRequest>()
                .With(x => x.DatePrescribed, DateTime.Today)
                .CreateMany(Samples)
                .ToList();

            requests.AddRange(fixture.Build<MedicationRequest>()
                .With(x => x.DatePrescribed, DateTime.Today.AddYears(-1))
                .CreateMany(Samples));

            var dateRequests = requests.Where(x => x.DatePrescribed == DateTime.Today).ToList();
            var dateCount = dateRequests.Count;

            repositoryMock.Setup(x => x.GetAsync(It.IsNotNull<MedicationRequest.RequestStatus>(), null, null)).ReturnsAsync(dateRequests);

            var controller = new MedicationRequestController(null, repositoryMock.Object);

            var result = await controller.Get(RequestStatus, null, null);
            var objectResult = result as ObjectResult;
            var resultList = objectResult?.Value as IList<GetMedicationRequest>;

            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal(dateCount, resultList?.Count);

            repositoryMock.VerifyAll();
        }

        [Fact]
        public async Task Get_Exception_ReturnsBadRequest()
        {
            repositoryMock.Setup(x => x.GetAsync(null, null, null)).Throws<Exception>();
            var medicationRequest = fixture.Create<MedicationRequest>();

            var controller = new MedicationRequestController(null, repositoryMock.Object);
            var result = await controller.Get(null,null,null);
            var objectResult = result as ObjectResult;

            Assert.Equal(400, objectResult?.StatusCode);
            repositoryMock.VerifyAll();
        }
    }
}
