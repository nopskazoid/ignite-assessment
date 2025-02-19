using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public enum PatientSex
        {
            Female,
            Male
        }

        public PatientSex Sex { get; set; }

        public virtual IEnumerable<MedicationRequest> MedicationRequests { get; set; }
    }
}
