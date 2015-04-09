using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FaleMaisDDD.MVC.Controllers
{
    
    public class AdminController : Controller
    {
        private IAdministradorService _service;
        private IUnitOfWorkService _uow;
        public AdminController(IUnitOfWorkService uow)
        {
            this._uow = uow;
            this._service = uow.Service<IAdministradorService>();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login(string Login, string Senha)
        {
            try
            {

                var autenticado = _service.Autenticar(Login, Senha);

                if (autenticado)
                {
                    FormsAuthentication.SetAuthCookie(Login, true);
                    return Json(new { text = "Autenticado, redirecionando...", type = "success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { text = "Usuario ou senha inválido", type = "warning" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { text = "Não foi possivel autenticar.", type = "error" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}