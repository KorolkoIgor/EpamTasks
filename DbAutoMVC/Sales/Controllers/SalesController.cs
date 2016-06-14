using DAL.Models;
using DAL.Repositories;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.Controllers
{
    public class SalesController : Controller
    {
        private SalesRepository salesContext = new SalesRepository();
        private ManagerRepository managersContext = new ManagerRepository();
        private ClientRepository clientsContext = new ClientRepository();
        private GoodsRepository goodsContext = new GoodsRepository();

        // GET: Sales
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.ManagersList = new SelectList(managersContext.Items.ToList(), dataValueField: "Id", dataTextField: "FirstName");
            ViewBag.ClientsList = new SelectList(clientsContext.Items.ToList(), dataValueField: "Id", dataTextField: "Name");
            ViewBag.GoodsList = new SelectList(goodsContext.Items.ToList(), dataValueField: "Id", dataTextField: "Name");

            return View();
        }
        // GET: Sales
        [Authorize]
        public ActionResult SalesTable(int? managerId, int? clientId, int? productId, DateTime? dateFrom, DateTime? dateTo)
        {

            DateTime dtFrom = (dateFrom ?? new DateTime(2000, 1, 1));
            DateTime dtTo = (dateTo ?? DateTime.Today);

            ViewBag.DateFrom = dtFrom;
            ViewBag.DateTo = dtTo;

            var salesData = salesContext.Items.Where(
                x => ((managerId == null ? x.Manager.Id > 0 : x.Manager.Id == managerId) &&
                     (clientId == null ? x.Client.Id > 0 : x.Client.Id == clientId) &&
                     (productId == null ? x.Goods.Id > 0 : x.Goods.Id == productId))
                ).Where(x => (x.Date >= dtFrom && x.Date <= dtTo)
                ).Select(x => new SalesViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Manager = x.Manager,
                    Client = x.Client,
                    Goods = x.Goods,
                    Cost = x.Cost
                }).OrderBy(x => x.Date);

             return View(salesData);

        }
           

        [Authorize]
        public PartialViewResult SalesFiltered(int? managerId, int? clientId, int? productId, DateTime? dateFrom, DateTime? dateTo)
        {

            DateTime dtFrom = (dateFrom ?? new DateTime(2000, 1, 1));
            DateTime dtTo = (dateTo ?? DateTime.Today);

            ViewBag.DateFrom = dtFrom;
            ViewBag.DateTo = dtTo;

            var salesData = salesContext.Items.Where(
                x => ((managerId == null ? x.Manager.Id > 0 : x.Manager.Id == managerId) &&
                     (clientId == null ? x.Client.Id > 0 : x.Client.Id == clientId) &&
                     (productId == null ? x.Goods.Id > 0 : x.Goods.Id == productId))
                ).Where(x => (x.Date >= dtFrom && x.Date <= dtTo)
                ).Select(x => new SalesViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Manager = x.Manager,
                    Client = x.Client,
                    Goods = x.Goods,
                    Cost = x.Cost
                }).OrderBy(x => x.Date);

             return PartialView(salesData);

        }

        [Authorize]
        public ActionResult Charts()
        {

            return View();
        }

        public JsonResult GetDataAssets()
        {
            var dataForchart = salesContext.Items.GroupBy(s => s.Manager.Id).Select(s =>
                new
                {
                    ManagerIdd = s.Key,
                    Sales = s.Sum(x => x.Cost)
                })
                .Join(managersContext.Items,
                    s => s.ManagerIdd,
                    m => m.Id,
                    (s, m) =>
                    new PieChartModel
                    {
                        Manager = m.FirstName,
                        TotalSales = s.Sales
                    });

       
            var data = dataForchart.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        

        //GET: Sales/Delete
        public ActionResult Delete(int? id)
        {
          
            var sale = salesContext.Items.FirstOrDefault(x => x.Id == id);
            
        
            salesContext.Remove(sale);
            salesContext.SaveSales();
            return View();
;
        }

       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        [HttpPost]
        public ActionResult Create(SalesViewModel sale)
        {
            if (ModelState.IsValid)
            {
                ManagerDTO manDTO = new ManagerDTO() { Id = sale.Manager.Id, FirstName = sale.Manager.FirstName, SecondName = sale.Manager.SecondName };
                GoodsDTO godDTO = new GoodsDTO() { Id = sale.Goods.Id, Name = sale.Goods.Name };
                ClientDTO clDTO = new ClientDTO() { Id = sale.Client.Id, Name = sale.Client.Name };
                //SalesDTO saleDTO = new SalesDTO(sale.Id, sale.Date, sale.Client, sale.Goods, sale.Manager, sale.Cost);

                managersContext.Add(manDTO);
                managersContext.SaveSales();
                clientsContext.Add(clDTO);
                clientsContext.SaveSales();
                goodsContext.Add(godDTO);
                goodsContext.SaveSales();
                var gg = goodsContext.Items.FirstOrDefault(x => x.Name == godDTO.Name);
                var mm = managersContext.Items.FirstOrDefault(x => x.FirstName == manDTO.FirstName);
                var cc = clientsContext.Items.FirstOrDefault(x => x.Name == clDTO.Name);

                SalesDTO saleDTO = new SalesDTO(sale.Id, sale.Date, cc, gg, mm, sale.Cost);
                             
                salesContext.Add(saleDTO);
                salesContext.SaveSales();
                return RedirectToAction("Index");
            }
            return View();
        }
        
       

       
    }
}
