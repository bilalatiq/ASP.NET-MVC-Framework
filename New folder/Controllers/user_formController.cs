using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class user_formController : Controller
    {
        // GET: user_form
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(user u)
        {
            u.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            user u = new user();
            u.us_id = int.Parse(id);
            u.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            user u = new user();
            u.us_id = int.Parse(id);
            TempData["us_id"] = u.us_id;
            user uu = u.search();
            return View(uu);
        }

        [HttpPost]
        public ActionResult update(user u)
        {
            u.us_id = (int)TempData["us_id"];
            u.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new user().showall());
        }
    }
}