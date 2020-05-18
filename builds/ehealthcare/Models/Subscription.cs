using System;
using System.Collections.Generic;
using eHealthcare.Models;

namespace eHealthcare.Models
{
    public partial class Subscription
    {
        public long Id { get; set; }
        public long ConsultationId { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }

        public virtual Consultation Consultation { get; set; }
    }
}
