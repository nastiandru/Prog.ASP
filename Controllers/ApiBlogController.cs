using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Controllers
{
    public class ApiBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
