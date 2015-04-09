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
using AutoMapper;
using FaleMaisDDD.MVC.Models.ViewModels;

namespace FaleMaisDDD.MVC.Controllers
{
    [Authorize]
    public class CadastroAdminController : Controller
    {
        private IAdministradorService db;
        private IUnitOfWorkService _uow;

        public CadastroAdminController(IUnitOfWorkService uow)
        {
            this._uow = uow;
            this.db = uow.Service<IAdministradorService>();
        }

        // GET: CadastroAdmin
        public ActionResult Index()
        {   
            var listView = new List<AdministradorViewModel>();
            db.GetAll().ToList().ForEach(el => listView.Add( Mapper.Map<Administrador, AdministradorViewModel>(el) ));
            return View(listView);
        }

        // GET: CadastroAdmin/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Get(p => p.Id == id.Value);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Administrador, AdministradorViewModel>(administrador));
        }

        // GET: CadastroAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,Ativo")] AdministradorViewModel administrador)
        {
            if (ModelState.IsValid)
            {
                administrador.Id = Guid.NewGuid();
                db.Add(Mapper.Map<AdministradorViewModel, Administrador>(administrador));
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        // GET: CadastroAdmin/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Get(p => p.Id == id.Value);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Administrador, AdministradorViewModel>(administrador));
        }

        // POST: CadastroAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,Ativo")] AdministradorViewModel administrador)
        {
            if (ModelState.IsValid)
            {
                db.Update(Mapper.Map<AdministradorViewModel, Administrador>(administrador));
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: CadastroAdmin/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Administrador administrador = db.Get(p => p.Id == id.Value);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Administrador,AdministradorViewModel>(administrador));
        }

        // POST: CadastroAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Administrador administrador = db.Get(p => p.Id == id);
            db.Remove(administrador);
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
