using AutoFixture;
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
            var repositoryMock = new Mock<MedicationRequestRepository>();
            repositoryMock.Setup(x => x.AddAsync(It.IsAny<MedicationRequest>())).ReturnsAsync(TestId);

            var  medicationRequest = fixture.Create<MedicationRequest>();

            var controller = new MedicationRequestController(null, repositoryMock.Object);
            var result = await controller.Post(medicationRequest);
            var objectResult = result as ObjectResult;

            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal(TestId, objectResult?.Value);

            repositoryMock.Verify();
        }

        public async Task Post_NoPatient_ReturnsBadRequest()
        {

        }

        public async Task Post_NoClinician_ReturnsBadRequest()
        {

        }

        public async Task Post_NoMedication_ReturnsBadRequest()
        {

        }

    }
}