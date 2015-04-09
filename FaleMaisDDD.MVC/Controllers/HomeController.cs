using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Domain.Interfaces.Services;
using FaleMaisDDD.Domain.Models;
using FaleMaisDDD.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaleMaisDDD.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private IPlanoRepository _repository;
        private ICalculoService _service;
        private IUnitOfWorkService _uow;

        public HomeController(IUnitOfWorkService uow)
        {
            this._uow = uow;
            this._repository = uow.Repository<IPlanoRepository>();
            this._service = uow.Service<ICalculoService>();
        }

        public ActionResult Index()
        {
            ViewBag.Planos = _repository.GetAll();
            return View();
        }

         public JsonResult Calcular(PedidoCalculo _pedido)
        {
            ResultadoCalculo tarifa = _service.CalcularValores(_pedido);
            return Json(tarifa, JsonRequestBehavior.AllowGet);
        }

    }
}
