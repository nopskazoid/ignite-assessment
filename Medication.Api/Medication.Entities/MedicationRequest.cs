using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Entities
{
    public class MedicationRequest
    {
        public int Id { get; set; }

        public virtual Patient? Patient { get; set; }
        public int PatientId { get; set; }

        public virtual Clinician? Clinician { get; set; }
        public int ClinicianId { get; set; }

        public virtual Medication? Medication { get; set; }
        public int MedicationId { get; set; }

        public string Reason { get; set; }

        public DateTime DatePrescribed { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateEnded { get; set; }

        public float Frequency { get; set; }

        public enum RequestStatus
        {
            Active,
            OnHold,
            Cancelled,
            Completed
        }

        public RequestStatus Status { get; set; }
    }
}
