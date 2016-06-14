using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class ClientsController : Controller
    {
        ClientRepository clientsRep = new ClientRepository();
        // GET: Clients
        public ActionResult Index()
        {
            return View(clientsRep.Items);
        }

        // GET: Clients/Edit
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit
        [HttpPost]
        public ActionResult Edit(ClientDTO client)
        {
            if (ModelState.IsValid)
            {
                clientsRep.Update(client);
                clientsRep.SaveSales();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(ClientDTO client)
        {
            if (ModelState.IsValid)
            {
                clientsRep.Add(client);
                clientsRep.SaveSales();
                return RedirectToAction("Index");
            }
            return View(client);
        }

      
       
        public ActionResult Delete(int? id)
        {
            try
            {
                ClientDTO client = clientsRep.Items.FirstOrDefault(x => x.Id == id);
                if (client != null)
                {
                    clientsRep.Remove(client);
                    clientsRep.SaveSales();
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
