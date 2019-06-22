using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class SubCategory_formController : Controller
    {
        // GET: SubCategory_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            return View();
        }
        [HttpPost]
        public ActionResult add(SubCategory sc)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            sc.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            SubCategory sc = new SubCategory();
            sc.subcat_id = int.Parse(id);
            sc.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            SubCategory sc = new SubCategory();
            sc.subcat_id = int.Parse(id);
            TempData["subcat_id"] = sc.subcat_id;
            SubCategory scc = sc.search();
            return View(scc);
        }

        [HttpPost]
        public ActionResult update(SubCategory sc)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            sc.subcat_id = (int)TempData["subcat_id"];
            sc.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new SubCategory().showall());
        }
    }
}