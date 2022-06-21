using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_PRAC_1;
using MVC_PRAC_1.Models;

namespace MVC_PRAC_1.Controllers
{
    public class Customer_DetailsController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Customer_Details
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomerDetailsIvys.ToListAsync());
        }

        // GET: Customer_Details/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = await db.CustomerDetailsIvys.FindAsync(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // GET: Customer_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerId,Id,CustomerName,CustomerPhone,Age,Address,Password")] Customer_Details customer_Details)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDetailsIvys.Add(customer_Details);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer_Details);
        }

        // GET: Customer_Details/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = await db.CustomerDetailsIvys.FindAsync(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // POST: Customer_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerId,Id,CustomerName,CustomerPhone,Age,Address,Password")] Customer_Details customer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Details).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer_Details);
        }

        // GET: Customer_Details/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = await db.CustomerDetailsIvys.FindAsync(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // POST: Customer_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer_Details customer_Details = await db.CustomerDetailsIvys.FindAsync(id);
            db.CustomerDetailsIvys.Remove(customer_Details);
            await db.SaveChangesAsync();
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
