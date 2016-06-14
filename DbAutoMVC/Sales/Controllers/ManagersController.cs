using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class ManagersController : Controller
    {
        private ManagerRepository managerRep = new ManagerRepository();

        // GET: Managers
        public ActionResult Index()
        {
            return View(managerRep.Items);
        }


        // GET: Managers/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        [HttpPost]
        public ActionResult Create(ManagerDTO manager)
        {
            if (ModelState.IsValid)
            {
                managerRep.Add(manager);
                managerRep.SaveSales();
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Managers/Edit/5
        [HttpPost]
        public ActionResult Edit(ManagerDTO manager)
        {
            if (ModelState.IsValid)
            {
                managerRep.Update(manager);
                managerRep.SaveSales();
                return RedirectToAction("Index");
            }
            return View(manager);
        }

   

        
        public ActionResult Delete(int? id)
        {
            try
            {
                ManagerDTO manager = managerRep.Items.FirstOrDefault(x => x.Id == id);
                if (manager != null)
                {
                    managerRep.Remove(manager);
                    managerRep.SaveSales();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

    }
}
