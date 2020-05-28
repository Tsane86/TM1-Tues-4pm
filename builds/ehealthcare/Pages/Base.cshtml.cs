﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace eHealthcare.Pages
{
    public class BaseModel : PageModel
    {
        public void OnPostLogout()
        {
            HttpContext.Session.Clear();
        }
    }
}