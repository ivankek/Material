using BD.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Servicios
{
    public class RazaService : IRazaService
    {
        public _20212cEjemplo2ParcialContext _ctx { get; set; }
        public RazaService(_20212cEjemplo2ParcialContext ctx)
        {
            _ctx = ctx;
        }

        public List<Raza> ObtenerTodos()
        {
            return _ctx.Razas.OrderBy(p => p.Nombre).ToList();
        }

        public void Crear(Raza raza)
        {
            _ctx.Razas.Add(raza);
            _ctx.SaveChanges();
        }

        //public void PerrosPorRaza()
        //{
        //    var countByRaza = _ctx.Perros.Include("IdRazaNavigation")
        //        .GroupBy(o => new { o.IdRazaNavigation.Nombre })
        //        .Select(o=> new { NombreRaza = o.Key, Cantidad = o.Distinct().Count() });
        //}
        public List<PerrosPorRaza> PerrosPorRaza()
        {
            var countByRaza = _ctx.Perros.Include("IdRazaNavigation")
                .GroupBy(o => new { o.IdRazaNavigation.Nombre })
                .Select(o => new PerrosPorRaza (){ NombreRaza = o.Key.Nombre, Cantidad = o.Distinct().Count() })
                .ToList();

            return countByRaza;
        }
    }

    public class PerrosPorRaza
    {
        public string NombreRaza { get; set; }
        public int Cantidad { get; set; }
    }
}
