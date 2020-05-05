using System;
using System.Collections.Generic;
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
    }
}
