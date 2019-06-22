using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class product_formController : Controller
    {
        // GET: product_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            ViewBag.k = new SelectList(new SubCategory().showall(), "subcat_id", "subcat_name");
            return View();
        }
        [HttpPost]
        public ActionResult add(product p)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            ViewBag.k = new SelectList(new SubCategory().showall(), "subcat_id", "subcat_name");
            p.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            product p = new product();
            p.prd_id = int.Parse(id);
            p.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            ViewBag.k = new SelectList(new SubCategory().showall(), "subcat_id", "subcat_name");
            product p = new product();
            p.prd_id = int.Parse(id);
            TempData["prd_id"] = p.prd_id;
            product pp = p.search();
            return View(pp);
        }

        [HttpPost]
        public ActionResult update(product p)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new category().showall(), "cat_id", "cat_name");
            ViewBag.k = new SelectList(new SubCategory().showall(), "subcat_id", "subcat_name");
            p.prd_id = (int)TempData["prd_id"];
            p.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new product().showall());
        }
    }
}