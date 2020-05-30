using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHealthcare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Pages
{
    public class patientAppointmentHubModel : BaseModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;
        
        public patientAppointmentHubModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Patient Patient { get; set; }
        public void OnGet()
        {
            //var patient = (from patients in _context.Patient
            //                 where patients.PersonId == Convert.ToInt64(HttpContext.Session.GetString("PersonId"))
            //                 select patients).First();
            //var appointments = _context.Consultation
            //                .Where(c => c.PatientId == Convert.ToInt64(HttpContext.Session.GetString("PersonId")))
            //                .Include(c => c.Doctor);
            Patient = _context.Patient
                .Where(p => p.PersonId == Convert.ToInt64(HttpContext.Session.GetString("PersonId")))
                .Include(s => s.Consultation)
                .ThenInclude(c => c.Doctor.Person)
                .FirstOrDefault();





        }
    }
}
