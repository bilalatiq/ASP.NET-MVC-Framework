using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class stock_formController : Controller
    {
        // GET: stock_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            return View();
        }
        [HttpPost]
        public ActionResult add(stock s)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            s.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            stock s = new stock();
            s.st_id = int.Parse(id);
            s.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            stock s = new stock();
            s.st_id = int.Parse(id);
            TempData["stock_id"] = s.st_id;
            stock ss = s.search();
            return View(ss);
        }

        [HttpPost]
        public ActionResult update(stock s)
        {
            ViewBag.i = new SelectList(new admin().showall(), "ad_id", "ad_name");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            s.st_id = (int)TempData["stock_id"];
            s.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new stock().showall());
        }
    }
}