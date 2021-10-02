using BatallaDeLosPenales.Servicios.Entidades;
using BatallaDeLosPenales.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatallaDeLosPenales.Controllers
{
    public class AltaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AltaArquero()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AltaArquero(int Id, string Nombre, string Apellido, bool Expulsado, int PenalesAtajados)
        {


            ArqueroServicio.Agregar(new Arquero(Id, Nombre, Apellido, Expulsado, PenalesAtajados));
            return Redirect("ListaArquero");


        }

        public IActionResult ListaArquero()
        {

            return View(ArqueroServicio.ObtenerTodos());

        }

        public IActionResult AltaDelantero()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AltaDelantero(int Id, string Nombre, string Apellido, bool Expulsado, int PenalesConvertidos)
        {

            DelanteroServicio.Agregar(new Delantero(Id, Nombre, Apellido, Expulsado, PenalesConvertidos));
            return Redirect("ListaDelantero");


        }


        public IActionResult ListaDelantero()
        {

            return View(DelanteroServicio.ObtenerTodos());

        }

        public IActionResult AltaDirectorTecnico()
        {


            //List<Delantero> delanteros = new List<Delantero>()
            //{

            //    new Delantero(1, "Lionel", "Messi", false, 4),
            //    new Delantero(2, "Mariano", "Pavone", false, 2),
            //};

            //List<Arquero> arqueros = new List<Arquero>()
            //{

            //   new Arquero(2, "Mariano", "Andujar", false, 2)
            //};

            //ArqueroServicio.Agregar(arqueros[0]);
            //DelanteroServicio.Agregar(delanteros[0]);
            //DelanteroServicio.Agregar(delanteros[1]);

            //ViewBag.Delanteros = delanteros;
            //ViewBag.Arqueros = arqueros;

            ViewBag.Delanteros = DelanteroServicio.ObtenerTodos();
            ViewBag.Arqueros = ArqueroServicio.ObtenerTodos();
            return View();

        }

        //[HttpPost]
        //public IActionResult AltaDirectorTecnico(DirectorTecnico directorTecnico)
        //{

        //    DirectorTecnicoServicio.Agregar(directorTecnico);

        //    return RedirectToAction("ListaDt", "Home");

        //}

        [HttpPost]
        public IActionResult AltaDirectorTecnico(string NombreUsuario, int Arquero, int Delantero1, int Delantero2)
        {

            //string nombreUsuario = Request.Form["NombreUsuario"];
            //string nombreUsuario = Request.Form["NombreUsuario"];

            List<Jugador> Jugadores = new List<Jugador>();

            DirectorTecnico directorTecnico1 = new DirectorTecnico("Carlos Bilardo", Jugadores);
            Arquero jugador1 = ArqueroServicio.ObtenerPorId(Arquero);
            Delantero jugador2 = DelanteroServicio.ObtenerPorId(Delantero1);
            Delantero jugador3 = DelanteroServicio.ObtenerPorId(Delantero2);

            Jugadores.Add(jugador1);
            Jugadores.Add(jugador2);
            Jugadores.Add(jugador3);

            DirectorTecnicoServicio.Agregar(new DirectorTecnico(NombreUsuario, Jugadores));

            return RedirectToAction("ListaDt", "Home");

        }

    }
}
