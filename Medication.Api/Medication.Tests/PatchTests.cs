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

namespace Medication.Tests
{
    public class PatchTests
    {
        private Mock<MedicationRequestRepository> repositoryMock;
        private Fixture fixture;

        public PatchTests()
        {
            repositoryMock = new Mock<MedicationRequestRepository>();
            fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Patch_ValidData_ReturnsSuccess()
        {
            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsNotNull<DateTime>(), It.IsNotNull<float>(), It.IsNotNull<MedicationRequest.RequestStatus>()));

            var patchRequest = fixture.Create<PatchMedicationRequest>();
            patchRequest.DateEnded = DateTime.UtcNow;

            var controller = new MedicationRequestController(null, repositoryMock.Object);

            var result = await controller.Patch(patchRequest) as StatusCodeResult;

            Assert.Equal(200, result?.StatusCode);
            repositoryMock.VerifyAll();
        }

        [Fact]
        public async Task Patch_Exception_ReturnsBadRequest()
        {
            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsNotNull<DateTime>(), It.IsNotNull<float>(), It.IsNotNull<MedicationRequest.RequestStatus>())).Throws<Exception>();

            var patchRequest = fixture.Create<PatchMedicationRequest>();
            patchRequest.DateEnded = DateTime.UtcNow;

            var controller = new MedicationRequestController(null, repositoryMock.Object);

            var result = await controller.Patch(patchRequest);
            var statusResult = result as BadRequestObjectResult;

            Assert.Equal(400, statusResult?.StatusCode);
            repositoryMock.VerifyAll();
        }
    }
}
