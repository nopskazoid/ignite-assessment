using Medication.Entities;

namespace Medication.Api.Contracts
{
    public class GetMedicationRequest
    {
        private MedicationRequest medicationRequest;

        public GetMedicationRequest(MedicationRequest medicationRequest)
        {
            this.medicationRequest = medicationRequest;
        }

        public int Id => medicationRequest.Id;

        public string Reason => medicationRequest.Reason;

        public DateTime DatePrescribed => medicationRequest.DatePrescribed;

        public DateTime DateStarted => medicationRequest.DateStarted;

        public DateTime DateEnded => medicationRequest.DateEnded;

        public float Frequency => medicationRequest.Frequency;

        public MedicationRequest.RequestStatus Status => medicationRequest.Status;

        public string CodeName { get; set; } 

        public string ClinicianFirstName { get; set; }

        public string ClinicianLastName { get; set; }
    }
}
