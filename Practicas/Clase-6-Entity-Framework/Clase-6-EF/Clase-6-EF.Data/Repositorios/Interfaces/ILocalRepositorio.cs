using Clase_6_EF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_6_EF.Data.Repositorios.Interfaces
{
    public interface ILocalRepositorio
    {
        public List<Local> ObtenerTodos();
        public void Agregar(Local local);
        public Local ObtenerPorId(int idLocal);
        public void Borrar(Local local);
        public void SaveChanges();
    }
}
