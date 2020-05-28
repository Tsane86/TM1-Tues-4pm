using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHealthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace eHealthcare.Pages
{
    public class newPatientModel : BaseModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;

        public newPatientModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public Patient Patient { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Patient.Person.Role = "Patient";
            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}