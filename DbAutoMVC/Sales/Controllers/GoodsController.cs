using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class GoodsController : Controller
    {
        GoodsRepository goodsContext = new GoodsRepository();
        // GET: Goods
        public ActionResult Index()
        {
            return View(goodsContext.Items);
        }


        // POST: Goods/Create

        // GET: Goods/Edit
        public ActionResult Edit(int id)
        {
            return View("Edit");
        }

        // POST: Goods/Edit
        [HttpPost]
        public ActionResult Edit(GoodsDTO product)
        {
            if (ModelState.IsValid)
            {
                goodsContext.Update(product);
                goodsContext.SaveSales();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // GET: Clients/Create

        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Clients/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(GoodsDTO good)
        {
            if (ModelState.IsValid)
            {
                goodsContext.Add(good);
                goodsContext.SaveSales();
                return RedirectToAction("Index");
            }
            return View(good);
        }
        public ActionResult Details(int id)
        {
            var item = goodsContext.Items.Where(x => x.Id == id).Select(x=>new GoodsDTO(){ Id=x.Id, Name=x.Name}).FirstOrDefault();
              
            return PartialView(item);
        }



    }
}
