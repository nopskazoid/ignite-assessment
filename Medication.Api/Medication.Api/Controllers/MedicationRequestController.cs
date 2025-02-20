using Medication.Api.Contracts;
using Medication.Api.Repositories;
using Medication.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Medication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationRequestController : ControllerBase
    {
        private readonly ILogger<MedicationRequestController> logger;
        private readonly MedicationRequestRepository repository;

        public MedicationRequestController(ILogger<MedicationRequestController> logger, MedicationRequestRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetMedicationRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(
            MedicationRequest.RequestStatus? status, 
            DateTime? startDate, 
            DateTime? endDate)
        {
            try
            {
                var requests = await repository.GetAsync(status, startDate, endDate);
                var response = requests.Select(x => new GetMedicationRequest(x)).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] MedicationRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.AddAsync(request);
                    await repository.SaveChangesAsync();
                    return Ok(request.Id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch([FromBody] PatchMedicationRequest request)
        {
            try
            {
                await repository.UpdateAsync(request.MedicationRequestId, request.DateEnded, request.Frequency, request.Status);
                await repository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
