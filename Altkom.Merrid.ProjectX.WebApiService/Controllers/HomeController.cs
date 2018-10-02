using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.Merrid.ProjectX.WebApiService.Controllers
{

    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Error()
        {
            return View("ERROR :-(");
        }
    }
}
