using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Controllers;

namespace MyProject.Web.Mvc.Controllers
{
    public class PersonsController : MyProjectControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}