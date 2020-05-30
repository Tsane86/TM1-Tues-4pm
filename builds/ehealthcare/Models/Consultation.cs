using System;
using System.Collections.Generic;

namespace eHealthcare.Models
{
    public partial class Consultation
    {
        public Consultation()
        {
            Subscription = new HashSet<Subscription>();
        }

        public long Id { get; set; }
        //public TimeSpan? ConsultationTime { get; set; }
        public DateTime? ConsultationDate { get; set; }
        public long? PatientId { get; set; }
        public long? DoctorId { get; set; }
        public long? MedicalCentreId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual MedicalCentre MedicalCentre { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }
    }
}
