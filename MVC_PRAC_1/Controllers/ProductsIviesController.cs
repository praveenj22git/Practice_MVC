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
    public class ProductsIviesController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: ProductsIvies
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductsIvys.ToListAsync());
        }

        // GET: ProductsIvies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsIvy productsIvy = await db.ProductsIvys.FindAsync(id);
            if (productsIvy == null)
            {
                return HttpNotFound();
            }
            return View(productsIvy);
        }

        // GET: ProductsIvies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsIvies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Product_Id,Id,Product_Name,Product_Price,Product_Manufacturing_date,Product_Expiry_date")] ProductsIvy productsIvy)
        {
            if (ModelState.IsValid)
            {
                db.ProductsIvys.Add(productsIvy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productsIvy);
        }

        // GET: ProductsIvies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsIvy productsIvy = await db.ProductsIvys.FindAsync(id);
            if (productsIvy == null)
            {
                return HttpNotFound();
            }
            return View(productsIvy);
        }

        // POST: ProductsIvies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Product_Id,Id,Product_Name,Product_Price,Product_Manufacturing_date,Product_Expiry_date")] ProductsIvy productsIvy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsIvy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productsIvy);
        }

        // GET: ProductsIvies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsIvy productsIvy = await db.ProductsIvys.FindAsync(id);
            if (productsIvy == null)
            {
                return HttpNotFound();
            }
            return View(productsIvy);
        }

        // POST: ProductsIvies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductsIvy productsIvy = await db.ProductsIvys.FindAsync(id);
            db.ProductsIvys.Remove(productsIvy);
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

        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult LoginEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginEmp(LoginEmp lg)
        {
            using (EntityContext db = new EntityContext())
            {
              //  id = lg.UserId;
                var users = db.CustomerDetailsIvys.Where(x => x.CustomerId == lg.UserId && x.CustomerName == lg.CustomerName && x.Password == lg.Password).ToList();
                if (users.Count > 0)
                {
                    Session["UserId"] = users[0].CustomerId;
                    Session["UserName"] = users[0].CustomerName;
                    return RedirectToAction("Index", "ProductsIvies");
                    // return RedirectToAction("Index", "Employees");
                }
                {
                    ViewBag.msg = "Incorrest userid/password";
                    //  TempData["msg"] = "Incorrest userid/password";
                }
            }
            return View();
        }
    }
}
