using System;
using System.Collections.Generic;

namespace eHealthcare.Models
{
    public partial class Person
    {
        public Person()
        {
            Patient = new HashSet<Patient>();
            Doctor = new HashSet<Doctor>();
        }


        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? Postcode { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        //public string Password { get; set; }
        //public virtual Doctor IdNavigation { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
