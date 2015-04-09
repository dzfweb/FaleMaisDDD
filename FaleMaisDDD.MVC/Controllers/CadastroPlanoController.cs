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
    public class CadastroPlanoController : Controller
    {
       private IPlanoService db;
       private IUnitOfWorkService _uow;

        public CadastroPlanoController(IUnitOfWorkService uow)
        {
            this._uow = uow;
            this.db = uow.Service<IPlanoService>();
        }

        // GET: CadastroPlano
        public ActionResult Index()
        {
            var listView = new List<PlanoViewModel>();
            db.GetAll().ToList().ForEach(el => listView.Add( Mapper.Map<Plano, PlanoViewModel>(el) ));
            return View(listView);
        }

        // GET: CadastroPlano/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Get(p => p.Id == id.Value);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Plano,PlanoViewModel>(plano));
        }

        // GET: CadastroPlano/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastroPlano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Minutos,Preco,TarifaExcedente,Ativo")] PlanoViewModel plano)
        {
            if (ModelState.IsValid)
            {
                plano.Id = Guid.NewGuid();
                db.Add(Mapper.Map<PlanoViewModel, Plano>(plano));
                _uow.Commit();                 
                return RedirectToAction("Index");
            }

            return View(plano);
        }

        // GET: CadastroPlano/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Get(p => p.Id == id.Value);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Plano,PlanoViewModel>(plano));
        }

        // POST: CadastroPlano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Minutos,Preco,TarifaExcedente,Ativo")] PlanoViewModel plano)
        {
            if (ModelState.IsValid)
            {
                db.Update(Mapper.Map<PlanoViewModel,Plano>(plano));
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(plano);
        }

        // GET: CadastroPlano/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Get(p => p.Id == id.Value);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Plano,PlanoViewModel>(plano));
        }

        // POST: CadastroPlano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Plano plano = db.Get(p => p.Id == id);
            db.Remove(plano);
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
