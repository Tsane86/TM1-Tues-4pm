using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eHealthcare.Models;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Pages
{
    public class consultationModel : BaseModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;

        public Person doctor1 { get; set; }

        public Person doctor2 { get; set; }

        public String Doctor1Name { get; set; }
        public String Doctor2Name { get; set; }

        public long Doctor1Id { get; set; }
        public long Doctor2Id { get; set; }

        public consultationModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Consultation Consultation { get; set; }
        public void OnGet()
        {
            var doctors = (from people in _context.Person   //gets person not doctors
                             where people.Role == "Doctor"
                              orderby people.Id
                              select people);
            
            if (doctors.Count() > 1)
            {
                Person doctor1 = doctors.FirstOrDefault();

                Person doctor2 = doctors.Skip(1).FirstOrDefault();

                Doctor1Name = doctor1.FirstName;

                Doctor2Name = doctor2.FirstName;
                var actualDoctors = (from doctora in _context.Doctor   
                               where doctora.PersonId == doctor1.Id || doctora.PersonId == doctor2.Id
                               orderby doctora.Id
                               select doctora);


                Doctor1Id = actualDoctors.First().Id;

                Doctor2Id = actualDoctors.Skip(1).FirstOrDefault().Id;
                
            }


            //doctor2 =_context.Doctor.FirstOrDefault();

            //doctor2 = (from doctors in _context.Doctor
            //                  orderby doctors.Id
            //                  select doctors).ElementAtOrDefault(1).ToString();
        }

        [BindProperty]
        public Consultation consultation{ get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Consultation");
            }
            var patientId = (from patients in _context.Patient
                             where patients.PersonId == Convert.ToInt64(HttpContext.Session.GetString("PersonId"))
                             select patients.Id).First();


            consultation.PatientId = patientId;

            var doctors = (from people in _context.Person
                           where people.Role == "Doctor"
                           orderby people.Id
                           select people);
            if (doctors.Count() > 1)
            {
                Person doctor1 = doctors.FirstOrDefault();

                Person doctor2 = doctors.Skip(1).FirstOrDefault();

                if (consultation.DoctorId == 1)
                {
                    consultation.DoctorId = doctor1.Id;
                }
                else if (consultation.DoctorId == 2)
                {
                    consultation.DoctorId = doctor2.Id;
                }
            }
            
            _context.Consultation.Add(consultation);
            _context.SaveChanges();

            return RedirectToPage("Consultation");
        }


    }
}
