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

        public int PatientId => medicationRequest.PatientId;

        public string Reason => medicationRequest.Reason;

        public DateTime DatePrescribed => medicationRequest.DatePrescribed;

        public DateTime DateStarted => medicationRequest.DateStarted;

        public DateTime DateEnded => medicationRequest.DateEnded;

        public float Frequency => medicationRequest.Frequency;

        public MedicationRequest.RequestStatus Status => medicationRequest.Status;

        public string CodeName => medicationRequest.Medication.CodeName;

        public string ClinicianFirstName => medicationRequest.Clinician.FirstName;

        public string ClinicianLastName => medicationRequest.Clinician.LastName;
    }
}
