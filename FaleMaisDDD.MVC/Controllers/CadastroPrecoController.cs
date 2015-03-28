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
    public class CadastroPrecoController : Controller
    {
        private IPrecoService db;
        private IDDDService dbDDD;

        public CadastroPrecoController(IPrecoService repository, IDDDService repositoryDDD)
        {
            this.db = repository;
            this.dbDDD = repositoryDDD;
        }

        // GET: CadastroPreco
        public ActionResult Index()
        {
           var listView = new List<PrecoViewModel>();
            db.BuscarTodos().ToList().ForEach(el => listView.Add(Mapper.Map<Preco, PrecoViewModel>(el) ));
            return View(listView);
        }

        // GET: CadastroPreco/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.BuscarPorId(id.Value);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Preco,PrecoViewModel>(preco));
        }

        // GET: CadastroPreco/Create
        public ActionResult Create()
        {
            ViewBag.IdDestino = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo");
            ViewBag.IdOrigem = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo");
            return View();
        }

        // POST: CadastroPreco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ValorMinuto,Ativo,IdOrigem,IdDestino")] PrecoViewModel preco)
        {
            if (ModelState.IsValid)
            {
                preco.Id = Guid.NewGuid();
                db.AdicionarNovo(Mapper.Map<PrecoViewModel, Preco>(preco));
                return RedirectToAction("Index");
            }

            ViewBag.IdDestino = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo", preco.IdDestino);
            ViewBag.IdOrigem = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo", preco.IdOrigem);
            return View(preco);
        }

        // GET: CadastroPreco/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.BuscarPorId(id.Value);
            if (preco == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDestino = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo", preco.IdDestino);
            ViewBag.IdOrigem = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo", preco.IdOrigem);
            return View(Mapper.Map<Preco,PrecoViewModel>(preco));
        }

        // POST: CadastroPreco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ValorMinuto,Ativo,IdOrigem,IdDestino")] PrecoViewModel preco)
        {
            if (ModelState.IsValid)
            {
                db.Atualizar(Mapper.Map<PrecoViewModel, Preco>(preco));
                return RedirectToAction("Index");
            }
            ViewBag.IdDestino = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo", preco.IdDestino);
            ViewBag.IdOrigem = new SelectList(dbDDD.BuscarTodos().Where(p => p.Ativo), "Id", "Codigo", preco.IdOrigem);
            return View(preco);
        }

        // GET: CadastroPreco/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preco preco = db.BuscarPorId(id.Value);
            if (preco == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Preco,PrecoViewModel>(preco));
        }

        // POST: CadastroPreco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Preco preco = db.BuscarPorId(id);
            db.Excluir(preco);
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
