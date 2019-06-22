using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class slaes_formController : Controller
    {
        // GET: slaes_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new invoice().showall(), "in_id", "in_date");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            return View();
        }
        [HttpPost]
        public ActionResult add(sales s)
        {
            ViewBag.i = new SelectList(new invoice().showall(), "in_id", "in_date");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            s.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            sales s = new sales();
            s.sls_id = int.Parse(id);
            s.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new invoice().showall(), "in_id", "in_date");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            sales s = new sales();
            s.sls_id = int.Parse(id);
            TempData["sales_id"] = s.sls_id;
            sales ss = s.search();
            return View(ss);
        }

        [HttpPost]
        public ActionResult update(sales s)
        {
            ViewBag.i = new SelectList(new invoice().showall(), "in_id", "in_date");
            ViewBag.j = new SelectList(new product().showall(), "prd_id", "prd_name");
            s.sls_id = (int)TempData["sales_id"];
            s.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new sales().showall());
        }
    }
}