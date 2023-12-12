using DatabaseFirstLibrary;
using EntityframeworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EntityframeworkDemo.Controllers
{
    public class CustomerController : Controller
    {

        DatabaseFirstLibrary.SomeBankEntities db = new SomeBankEntities();
        // GET: Customer
        public ActionResult Index()
        {


            List<Customer> customers = db.Customers.ToList();
            List<CustModel> custlist = new List<CustModel>();
            foreach (var item in customers)
            {
                CustModel model = new CustModel();
                model.Custid = item.Custid;
                model.CustName = item.Custname;
                model.City = item.City;
                custlist.Add(model);
            }

            return View(custlist);
            
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {

            Customer c = db.Customers.Find(id);
            CustModel model = new CustModel();
            model.Custid = c.Custid;
            model.CustName = c.Custname;
            model.City = c.City;
            return View(model);
            
        }

        // GET: Customer/Create


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
            {
                // TODO: Add insert logic here
                CustModel model = new CustModel();
                //model.Custid=Convert.ToInt32(collection["Custid"]);
                model.CustName = collection["CustName"].ToString();
                model.City = collection["City"].ToString();

                Customer c = new Customer();
                c.Custname = model.CustName;
                c.City = model.City;
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           ;
        }

        

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer custdata = db.Customers.Find(id);
            CustModel model = new CustModel();
            model.Custid = custdata.Custid;
            model.CustName = custdata.Custname;
            model.City = custdata.City;
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Customer custdata = db.Customers.Find(id);
                custdata.Custname = collection["CustName"].ToString();
                custdata.City = collection["City"].ToString();
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {

            Customer custdata = db.Customers.Find(id);
            CustModel model = new CustModel();
            model.Custid = custdata.Custid;
            model.CustName = custdata.Custname;
            model.City = custdata.City;
            return View(model);
            
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Customer c = db.Customers.Find(id);
                db.Customers.Remove(c);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
