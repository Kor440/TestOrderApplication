using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestOrderApplication.Models;
using TestOrderApplication.ViewModels;

namespace TestOrderApplication.Controllers
{
    public class OrdersController : Controller
    {
        private OrderDbContext db = new OrderDbContext();

        // GET: Orders
        /*public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Provider);
            //var order = from o in db.Order select o;
            return View(order.ToList());
        }*/
        
        public ActionResult Index(string provider, string number, DateTime? dateFrom, DateTime? dateTo, string itemName, string itemUnit)
        {

            var orders = db.Order.Include(o => o.Provider).Include(o => o.OrderItem);


            var providerName = orders.Select(p => p.Provider.Name).ToList().Distinct();
            if (providerName != null)
            {
                ViewBag.ProviderName = providerName;
            }

            var orderNumber = orders.Select(p => p.Number).ToList().Distinct();
            if (orderNumber != null)
            {
                ViewBag.OrderNumber = orderNumber;
            }

            ViewBag.DateFrom = ViewBag.fromDate;
            ViewBag.DateTo = ViewBag.fromDate;

            var orderItems = orders.SelectMany(o => o.OrderItem);
            
            var orderItemName = orderItems.Select(p => p.Name).ToList().Distinct();
            if (orderItemName != null)
            {
                ViewBag.ItemName = orderItemName;
            }

            var orderItemUnit = orderItems.Select(p => p.Unit).ToList().Distinct();
            if (orderItemUnit != null)
            {
                ViewBag.ItemUnit = orderItemUnit;
            }

                if (!String.IsNullOrEmpty(provider))
            {
                orders = orders.Where(p => p.Provider.Name.Equals(provider));
            }

            if (!String.IsNullOrEmpty(number))
            {
                orders = orders.Where(p => p.Number.Equals(number));
            }

            if (dateFrom != null && dateTo != null)
            {
                orders = orders.Where(o => o.Date >= dateFrom
                    && o.Date <= dateTo);
            }


            if (!String.IsNullOrEmpty(itemName))
            {
                orders = orders.Where(p => p.OrderItem.Any(m => m.Name == itemName));
                
            }
            
            if (!String.IsNullOrEmpty(itemUnit))
            {

                orders = orders.Where(p => p.OrderItem.Any(m=>m.Unit == itemUnit));
                
            }

            return View(orders.ToList());
        }


        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            
            if (order == null)
            {
                return HttpNotFound();
            }
            IQueryable<OrderItem> orders = from or in db.OrderItem.Include(o => o.Order).Include(o => o.Order.Provider) select or;


            var orderD = orders.Select(o => o.OrderId == id).ToList();

            if (orderD != null)
            {
                ViewBag.Order = orderD;
            }

            var orderItem = orders.Where(o => o.OrderId == id).ToList();
            if (orderItem != null)
            {
                ViewBag.OrderItems = orderItem;
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDetailsConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Orders/Create
        public ActionResult Create()
        {
            
            BigViewModel model = new BigViewModel();
            
            List<OrderItem> orderItemsList = new List<OrderItem>
            {
                new OrderItem{  Name = "", Quantity = 0, Unit = "" }
            };

            model.orderItemsList = orderItemsList;

            ViewBag.ProviderId = new SelectList(db.Provider, "Id", "Name");
            return View(model);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BigViewModel createOrder)
        {

            if (ModelState.IsValid)
            {
                db.Order.Add(createOrder.Order);
                db.SaveChanges();
                //createOrder.OrderItem.OrderId = createOrder.Order.Id;
                //db.OrderItem.Add(createOrder.OrderItem);
                foreach (var i in createOrder.orderItemsList)
                {
                    i.OrderId = createOrder.Order.Id;
                    db.OrderItem.Add(i);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.ProviderId = new SelectList(db.Provider, "Id", "Name", createOrder.Order.ProviderId);
            return View(createOrder);
        }


        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BigViewModel model = new BigViewModel();
            //var orders = db.Order.Include(o => o.Provider).Include(o => o.OrderItem);
            //model.Order = orders.Where(o=>o.Id.Equals(id));
            model.Order = db.Order.Include(o => o.Provider).Include(o => o.OrderItem).FirstOrDefault(x => x.Id == id);

            //model.Order =
            if (model.Order == null)
            {
                return HttpNotFound();
            }
            
            model.orderItemsList = model.Order.OrderItem.ToList();

            ViewBag.ProviderId = new SelectList(db.Provider, "Id", "Name", model.Order.ProviderId);
            return View(model);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BigViewModel editOrder)
        {

            if (ModelState.IsValid)
            {
                db.Entry(editOrder.Order).State = EntityState.Modified;
                db.SaveChanges();
                //var dbw = db.OrderItem.Where(o => o.OrderId == editOrder.Order.Id);

                foreach (var i in editOrder.orderItemsList)
                {
                    if (i.Id == 0)
                    {
                        i.OrderId = editOrder.Order.Id;
                        db.OrderItem.Add(i);
                    }
                    var d = db.OrderItem.Find(i.Id);
                    d.Name = i.Name;
                    d.Quantity = i.Quantity;
                    d.Unit = i.Unit;    
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderId = new SelectList(db.Provider, "Id", "Name", editOrder.Order.ProviderId);
            return View(editOrder);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
