using BD.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Servicios
{
    public class PerroService : IPerroService
    {
        public _20212cEjemplo2ParcialContext _ctx { get; set; }
        public PerroService(_20212cEjemplo2ParcialContext ctx)
        {
            _ctx = ctx;
        }

        public List<Perro> ObtenerTodos()
        {
            return _ctx.Perros.OrderBy(p=> p.Nombre).ToList();
        }

        public List<Perro> ObtenerMenores(int edad)
        {
            return _ctx.Perros.Where(p=> p.Edad < edad).OrderBy(p=> p.Nombre).ToList();
        }

        public void Crear(Perro perro)
        {
            _ctx.Perros.Add(perro);
            _ctx.SaveChanges();
        }
    }
}
