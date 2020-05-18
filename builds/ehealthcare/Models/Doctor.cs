using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace eHealthcare.Models
{
    public class Doctor
    {
        public int ID { get; set; }             
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }

        public string address { get; set; }
        public string address2 { get; set; }
        public int postcode { get; set; }
        //public String Suburb { get; set; }
        public string state { get; set; }       
        public string city { get; set; }
        public string gender { get; set; }
        public string doctorIDNumber { get; set; }
=======

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

        public virtual Person Person { get; set; }
        public virtual ICollection<Consultation> Consultation { get; set; }
        public virtual ICollection<MedicalCentre> MedicalCentre { get; set; }
>>>>>>> Stashed changes
    }
}
