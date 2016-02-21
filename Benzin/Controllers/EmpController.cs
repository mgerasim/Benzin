using Benzin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benzin.Controllers
{
    public class EmpController : Controller
    {
        //
        // GET: /Emp/

        public ActionResult Index()
        {
            List<Emp> theEmpList = Emp.GetAll();
            return View(theEmpList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Emp model = new Emp();
                model.payed_at = Convert.ToDateTime(collection.Get("payed_at"));
                model.probeg = Convert.ToInt32(collection.Get("probeg"));
                model.litrs = Convert.ToInt32(collection.Get("litrs"));
                model.summa = Convert.ToDecimal(collection.Get("summa"));
                model.Save();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return this.Create();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Benzin.Models.Emp.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Emp model = Emp.GetById(id);
                model.payed_at = DateTime.Now;// Convert.ToDateTime(collection.Get("payed_at"));
                model.probeg = Convert.ToInt32(collection.Get("probeg"));
                model.litrs = Convert.ToInt32(collection.Get("litrs"));
                model.summa = Convert.ToDecimal(collection.Get("summa"));
                model.Update();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return this.Edit(id);
            }
        }

        public ActionResult Delete(int id)
        {
            Emp model = Emp.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Emp model = Emp.GetById(id);

                model.Delete();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.ToString();

                return View();
            }
        }

    }
}
