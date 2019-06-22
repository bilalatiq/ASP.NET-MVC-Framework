using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class admin_formController : Controller
    {
        // GET: admin_form
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(admin a)
        {
            a.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            admin a = new admin();
            a.ad_id =int.Parse(id);
            a.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            admin a = new admin();
            a.ad_id = int.Parse(id);
            TempData["ad_id"] = a.ad_id;
            admin aa = a.search();
            return View(aa);
        }

        [HttpPost]
        public ActionResult update(admin a)
        {
            a.ad_id=(int)TempData["ad_id"];
            a.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new admin().showall());
        }
    }
}