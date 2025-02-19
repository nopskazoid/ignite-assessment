using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Entities
{
    public class Medication
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string CodeName { get; set; }

        public string CodeSystem { get; set; }

        public float StrengthValue { get; set; }

        public string StrengthUnit { get; set; }

        public enum MedicationForm
        {
            Powder,
            Tablet,
            Capsule,
            Syrup
        }

        public MedicationForm Form { get; set; }
    }
}
