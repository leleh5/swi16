using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP02.DAO;
using TP02.Models;

namespace TP02.Controllers
{
    public class BLsController : Controller
    {
        private PortoContext db = new PortoContext();

        // GET: BLs
        public ActionResult Index()
        {
            return View(db.BLs.ToList());
        }

        // GET: BLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL bL = db.BLs.Find(id);
            if (bL == null)
            {
                return HttpNotFound();
            }
            return View(bL);
        }

        // GET: BLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BLs/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero,Consignee,Navio")] BL bL)
        {
            if (ModelState.IsValid)
            {
                db.BLs.Add(bL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bL);
        }

        // GET: BLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL bL = db.BLs.Find(id);
            if (bL == null)
            {
                return HttpNotFound();
            }
            return View(bL);
        }

        // POST: BLs/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero,Consignee,Navio")] BL bL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bL);
        }

        // GET: BLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL bL = db.BLs.Find(id);
            if (bL == null)
            {
                return HttpNotFound();
            }
            return View(bL);
        }

        // POST: BLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL bL = db.BLs.Find(id);
            db.BLs.Remove(bL);
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
