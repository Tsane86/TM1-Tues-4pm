using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eHealthcare.Models;

namespace eHealthcare.Pages
{
    public class consultationModel : BaseModel
    {
        private readonly eHealthcare.Data.ApplicationDbContext _context;

        public consultationModel(eHealthcare.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Consultation Consultation { get; set; }
        public void OnGet()
        {

        }


    }
}
