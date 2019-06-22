using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class category_formController : Controller
    {
        // GET: category_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            return View();
        }
        [HttpPost]
        public ActionResult add(category c)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            c.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            category c = new category();
            c.cat_id = int.Parse(id);
            c.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            category c = new category();
            c.cat_id = int.Parse(id);
            TempData["cat_id"] = c.cat_id;
            category cc = c.search();
            return View(cc);
        }

        [HttpPost]
        public ActionResult update(category c)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            c.cat_id = (int)TempData["cat_id"];
            c.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new category().showall());
        }
    }
}