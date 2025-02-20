using AutoFixture;
using Medication.Api.Contracts;
using Medication.Api.Controllers;
using Medication.Api.Repositories;
using Medication.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Medication.Tests
{
    public class PostTests
    {
        private Mock<MedicationRequestRepository> repositoryMock;
        private Fixture fixture;

        public PostTests()
        {
            repositoryMock = new Mock<MedicationRequestRepository>();
            fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        private const int TestId = 13;

        [Fact]
        public async Task Post_ValidData_ReturnsSuccess()
        {
            repositoryMock.Setup(x => x.AddAsync(It.IsAny<MedicationRequest>())).Callback<MedicationRequest>(x => x.Id = TestId);

            var  medicationRequest = fixture.Create<MedicationRequest>();

            var controller = new MedicationRequestController(null, repositoryMock.Object);
            var result = await controller.Post(medicationRequest);
            var objectResult = result as ObjectResult;

            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal(TestId, objectResult?.Value);

            repositoryMock.Verify();
        }

        [Fact]
        public async Task Post_Exception_ReturnsBadRequest()
        {
            repositoryMock.Setup(x => x.AddAsync(It.IsAny<MedicationRequest>())).Throws<Exception>();
            var medicationRequest = fixture.Create<MedicationRequest>();

            var controller = new MedicationRequestController(null, repositoryMock.Object);
            var result = await controller.Post(medicationRequest);
            var objectResult = result as ObjectResult;
            var statusResult = result as BadRequestObjectResult;

            Assert.Equal(400, statusResult?.StatusCode);
            repositoryMock.VerifyAll();
        }
    }
}