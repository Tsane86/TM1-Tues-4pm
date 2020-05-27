using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eHealthcare.Models;
using Microsoft.Extensions.Configuration;
using static eHealthcare.Startup;

namespace eHealthcare.Pages
{
    public class loginModel : PageModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;

        public loginModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void OnGet()
        {

        }
        [BindProperty]
        public string EmailAddress { get; set; }



        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        public IActionResult OnPost()
        {

            Person person = (from people in _context.Person
                               where people.EmailAddress == EmailAddress && people.Password == Password
                               select people).FirstOrDefault();
            if (person != null) 
            {
                //Person getPersonFromPatient = (from people in _context.Person
                //                               where people.Id == patient.PersonId
                //                               select people).FirstOrDefault();
                HttpContext.Session.SetString("FirstName", person.FirstName);
                HttpContext.Session.SetString("Role", person.Role);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}