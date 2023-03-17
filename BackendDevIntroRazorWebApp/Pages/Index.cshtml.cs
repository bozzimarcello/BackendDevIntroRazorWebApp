using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackendDevIntroRazorWebApp.Models;
using BackendDevIntroRazorWebApp.Services;

namespace BackendDevIntroRazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Customer> customers;

        public void OnGet()
        {
            customers = CustomersService.GetAll();    
        }
    }
}
