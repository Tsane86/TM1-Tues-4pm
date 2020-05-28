using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eHealthcare.Models;

namespace eHealthcare.Pages
{
    public class newDoctorModel : PageModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;

        public newDoctorModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public Doctor Doctor { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Doctor.Add(Doctor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}