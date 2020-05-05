using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace eHealthcare.Models
{
    public class Patient
    {
        public int ID { get; set; }             //start of shared 'user' properties
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public int postcode { get; set; }
        //public String Suburb { get; set; }
        public string state { get; set; }       //end of shared 'user' properties
        public string city { get; set; }
        public string gender { get; set; }
        public string patient_Email { get; set; }
        public string medicareNumber { get; set; }
        //public int MedicareId { get; set; }

    }
}
