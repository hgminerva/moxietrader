using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moxietrader.Controllers
{
    public class ChartController : Controller
    {

        // GET: /Chart/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}