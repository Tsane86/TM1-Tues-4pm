using System;
using System.Collections.Generic;

namespace eHealthcare.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Consultation = new HashSet<Consultation>();
        }

        public long Id { get; set; }
        public string PatientEmail { get; set; }
        public string MedicareNum { get; set; }
        public int? MedicareId { get; set; }
        public long? PersonId { get; set; }
        public long? ConsultationId { get; set; }
        public long? SubscriptionId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Consultation> Consultation { get; set; }
    }
}
