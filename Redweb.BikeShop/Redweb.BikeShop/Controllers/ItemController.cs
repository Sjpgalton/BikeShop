using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redweb.BikeShop.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult AllItems()
        {
            return View();
        }
    }
}