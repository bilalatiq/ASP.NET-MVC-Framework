using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class invoice_formController : Controller
    {
        // GET: invoice_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new user().showall(), "us_id", "us_email");
            return View();
        }
        [HttpPost]
        public ActionResult add(invoice i)
        {
            ViewBag.i = new SelectList(new user().showall(), "us_id", "us_email");
            i.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            invoice i = new invoice();
            i.in_id = int.Parse(id);
            i.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new user().showall(), "us_id", "us_email");
            invoice i = new invoice();
            i.in_id = int.Parse(id);
            TempData["invoice_id"] = i.in_id;
            invoice ii = i.search();
            return View(ii);
        }

        [HttpPost]
        public ActionResult update(invoice i)
        {
            ViewBag.i = new SelectList(new user().showall(), "us_id", "us_email");
            i.in_id = (int)TempData["invoice_id"];
            i.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new invoice().showall());
        }
    }
}