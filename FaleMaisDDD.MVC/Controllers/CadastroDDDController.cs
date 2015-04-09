using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Infra.Data;
using FaleMaisDDD.Domain.Interfaces.Services;
using FaleMaisDDD.MVC.Models.ViewModels;
using AutoMapper;

namespace FaleMaisDDD.MVC.Controllers
{
    [Authorize]
    public class CadastroDDDController : Controller
    {
        private IDDDService db;
        private IUnitOfWorkService _uow;
        public CadastroDDDController(IUnitOfWorkService uow)
            
        {
            this._uow = uow;
            db = uow.Service<IDDDService>();
        }

        // GET: CadastroDDD
        public ActionResult Index()
        {
           var listView = new List<DDDViewModel>();
            db.Ativos().ToList().ForEach(el => listView.Add(Mapper.Map<DDD, DDDViewModel>(el)));
            return View(listView);
        }

        // GET: CadastroDDD/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDD dDD = db.Find(p => p.Id == id).FirstOrDefault();
            if (dDD == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DDD, DDDViewModel>(dDD));
        }

        // GET: CadastroDDD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroDDD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Ativo")] DDDViewModel dDD)
        {
            if (ModelState.IsValid)
            {
                dDD.Id = Guid.NewGuid();
                db.Add(Mapper.Map<DDDViewModel,DDD>(dDD));
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(dDD);
        }

        // GET: CadastroDDD/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDD dDD = db.Find(p => p.Id == id.Value).FirstOrDefault();
            if (dDD == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DDD,DDDViewModel>(dDD));
        }

        // POST: CadastroDDD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Ativo")] DDDViewModel dDD)
        {
            if (ModelState.IsValid)
            {
                db.Update(Mapper.Map<DDDViewModel, DDD>(dDD));
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(dDD);
        }

        // GET: CadastroDDD/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDD dDD = db.Find(p => p.Id == id.Value).FirstOrDefault();
            if (dDD == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<DDD,DDDViewModel>(dDD));
        }

        // POST: CadastroDDD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DDD dDD = db.Find(p => p.Id == id).FirstOrDefault();
            db.Remove(dDD);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              
            }
            base.Dispose(disposing);
        }
    }
}
