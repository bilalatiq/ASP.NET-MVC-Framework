using DB_ProjectTRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_ProjectTRY.Controllers
{
    public class image_formController : Controller
    {
        // GET: image_form
        public ActionResult add()
        {
            ViewBag.i = new SelectList(new product().showall(), "prd_id", "prd_name");
            return View();
        }
        [HttpPost]
        public ActionResult add(image i)
        {
            ViewBag.i = new SelectList(new product().showall(), "prd_id", "prd_name");
            i.add();
            return RedirectToAction("show");
        }

        public ActionResult delete(string id)
        {
            image i = new image();
            i.img_id = int.Parse(id);
            i.delete();
            return RedirectToAction("show");
        }

        public ActionResult update(string id)
        {
            ViewBag.i = new SelectList(new product().showall(), "prd_id", "prd_name");
            image i = new image();
            i.img_id = int.Parse(id);
            TempData["img_id"] = i.img_id;
            image ii = i.search();
            return View(ii);
        }

        [HttpPost]
        public ActionResult update(image i)
        {
            ViewBag.i = new SelectList(new product().showall(), "prd_id", "prd_name");
            i.img_id = (int)TempData["img_id"];
            i.update();
            return RedirectToAction("show");
        }


        public ActionResult show()
        {
            return View(new image().showall());
        }
    }
}
