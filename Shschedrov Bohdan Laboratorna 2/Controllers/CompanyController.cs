using Microsoft.AspNetCore.Mvc;
using Shschedrov_Bohdan_Laboratorna_2.Services;
using Shschedrov_Bohdan_Laboratorna_2.Models;

namespace Shschedrov_Bohdan_Laboratorna_2.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var largestCompany = _companyService.GetLargestCompany();
            return View(largestCompany);
        }
    }
}
