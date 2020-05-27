using System;
using System.Collections.Generic;

namespace eHealthcare.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Consultation = new HashSet<Consultation>();
            MedicalCentre = new HashSet<MedicalCentre>();
        }

        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public string Speciality { get; set; }
        public long PersonId { get; set; }
        public long? MedicalCentreId { get; set; }
        public long? ConsultationId { get; set; }
        public long? PrescriptionId { get; set; }
        public string DoctorPassword { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Consultation> Consultation { get; set; }
        public virtual ICollection<MedicalCentre> MedicalCentre { get; set; }
    }
}
