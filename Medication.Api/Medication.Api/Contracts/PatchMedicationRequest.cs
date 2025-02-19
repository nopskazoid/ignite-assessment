using Medication.Entities;
using Microsoft.AspNetCore.Components.Web;

namespace Medication.Api.Contracts
{
    public class PatchMedicationRequest
    {
        public int MedicationRequestId { get; set; }

        public DateTime? DateEnded { get; set; }

        public float? Frequency { get; set; }

        public MedicationRequest.RequestStatus? Status { get; set; }
    }
}
