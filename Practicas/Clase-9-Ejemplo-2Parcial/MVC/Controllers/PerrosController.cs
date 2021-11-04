using BD.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PerrosController : Controller
    {
        private IPerroService _perroService;
        private IRazaService _razaService;
        public PerrosController(IPerroService perroService, IRazaService razaService)
        {
            _perroService = perroService;
            _razaService = razaService;
        }
        public ActionResult Crear()
        {
            //_razaService.PerrosPorRaza();
            ViewBag.Razas = _razaService.ObtenerTodos();
            return View();
        }

        // POST: PerrosController/Create
        [HttpPost]
        public ActionResult Crear(Perro perro)
        {
            try
            {
                string otraRaza = Request.Form["otraRaza"];
                if (!string.IsNullOrEmpty(otraRaza))
                {
                    Raza nuevaRaza = new Raza();
                    nuevaRaza.Nombre = otraRaza;
                    _razaService.Crear(nuevaRaza);
                    perro.IdRaza = nuevaRaza.IdRaza;
                }
                _perroService.Crear(perro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
