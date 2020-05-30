using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHealthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eHealthcare.Pages
{
    public class doctorDashboardModel : BaseModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;

        public doctorDashboardModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Doctor Doctor { get; set; }
        [BindProperty]
        public Consultation Consultation { get; set; }
        public void OnGet()
        {
            Doctor = _context.Doctor
                .Where(d => d.PersonId == Convert.ToInt64(HttpContext.Session.GetString("PersonId")))
                .Include(s => s.Consultation)
                .ThenInclude(c => c.Patient.Person)
                .FirstOrDefault();
        }
        public IActionResult OnPostDelete()
        {
            var consultation = _context.Consultation.Find(Consultation.Id);
            _context.Consultation.Remove(consultation);
            _context.SaveChanges();

            return RedirectToPage("doctorDashboard");
        }
    }
}