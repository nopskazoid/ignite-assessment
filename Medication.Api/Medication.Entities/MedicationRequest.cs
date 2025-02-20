using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Entities
{
    public class MedicationRequest
    {
        public int Id { get; set; }

        public virtual Patient? Patient { get; set; }

        [Required]
        public int PatientId { get; set; }

        public virtual Clinician? Clinician { get; set; }

        [Required]
        public int ClinicianId { get; set; }

        public virtual Medication? Medication { get; set; }

        [Required]
        public int MedicationId { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public DateTime DatePrescribed { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        [Required]
        public DateTime DateEnded { get; set; }

        [Required]
        public float Frequency { get; set; }

        public enum RequestStatus
        {
            Active,
            OnHold,
            Cancelled,
            Completed
        }

        [Required]
        public RequestStatus Status { get; set; }
    }
}
