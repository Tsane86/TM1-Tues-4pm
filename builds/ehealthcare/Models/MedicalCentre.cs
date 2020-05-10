using System;
using System.Collections.Generic;

namespace eHealthcare.Models
{
    public partial class MedicalCentre
    {
        public MedicalCentre()
        {
            Consultation = new HashSet<Consultation>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public string StreetNo { get; set; }
        public string Suburb { get; set; }
        public int? Postcode { get; set; }
        public string State { get; set; }
        public long? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Consultation> Consultation { get; set; }
    }
}
