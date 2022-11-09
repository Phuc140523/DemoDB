using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;

namespace DemoDB.Controllers
{
    public class CustomerController : Controller
    {
        DBSportStoreEntities db = new DBSportStoreEntities();
        // GET: Customer
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                return View(db.Customers.ToList());
            }
            else
                return View(db.Customers.Where(s => s.NameCus.Contains(_name)).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            try
            {
                db.Customers.Add(cust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("error Create new");
            }
        }
        public ActionResult Details(int id)
        {
            return View(db.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(db.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id,Customer cust)
        {
            db.Entry(cust).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Customer cust)
        {
            try
            { cust=db.Customers.Where(s=>s.IDCus==id).FirstOrDefault();
                db.Customers.Remove(cust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content(" this data is using in other table, Error Delete! ");
            }
        }
        

    }
}