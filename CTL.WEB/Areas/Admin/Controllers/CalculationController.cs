using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTL.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CalculationController : Controller
    {
        // GET: Admin/Calculation
        public ActionResult Index()
        {
            return View();
        }
    }
}