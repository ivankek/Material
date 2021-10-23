using Clase_6_EF.Data.EF;
using Clase_6_EF.Data.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_6_EF.Data.Repositorios
{
    public class LocalRepositorio : ILocalRepositorio
    {
        private Db_TiendaContext _ctx;

        public LocalRepositorio(Db_TiendaContext ctx)
        {
            _ctx = ctx;
        }

        public List<Local> ObtenerTodos()
        {
            return _ctx.Locals.OrderBy(o=> o.Nombre).ToList();
        }

        public void Agregar(Local local)
        {
            _ctx.Locals.Add(local);
        }

        public Local ObtenerPorId(int idLocal)
        {
            return _ctx.Locals.Find(idLocal);
        }

        public void Borrar(Local local)
        {
            _ctx.Locals.Remove(local);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

    }
}
