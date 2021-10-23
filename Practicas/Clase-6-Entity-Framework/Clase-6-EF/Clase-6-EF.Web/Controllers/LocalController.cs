using Clase_6_EF.Data.EF;
using Clase_6_EF.Servicios;
using Clase_6_EF.Servicios.Interfaces;
using Clase_6_EF.Web.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_6_EF.Web.Controllers
{
    public class LocalController : Controller
    {
        private ILocalServicio _localServicio;
        private IOperacionesLogic _operacionesLogic;

        public LocalController(ILocalServicio localServicio, IOperacionesLogic operacionesLogic)
        {
            _localServicio = localServicio;
            _operacionesLogic = operacionesLogic;
        }
        // GET: LocalController
        public ActionResult Lista()
        {
            //Db_TiendaContext ctx = new Db_TiendaContext();
            //Data.Repositorios.LocalRepositorio localRepo = new Data.Repositorios.LocalRepositorio(ctx);
            //LocalServicio localServicio = new LocalServicio(localRepo);

            List<Local> locales = _localServicio.ObtenerTodos();
            ViewBag.Operaciones = _operacionesLogic.Obtener();
            return View(locales);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Local local)
        {
            _localServicio.Agregar(local);
            _operacionesLogic.Agregar($"Local {local.Nombre} agregado con éxito.");
            return Redirect("/local/lista");
        }

        [HttpGet]
        public ActionResult Borrar(int id)
        {
            _localServicio.Borrar(id);
            return Redirect("/local/lista");
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            try
            {
                Local local = _localServicio.ObtenerPorId(id);
                return View(local);
            }
            catch (ArgumentException)
            {
                return Redirect("/local/lista");
            }
        }

        [HttpPost]
        public ActionResult Modificar(Local local)
        {
            _localServicio.Modificar(local);
            return Redirect("/local/lista");
        }
    }
}
