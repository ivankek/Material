using BD.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IPerroService
    {
        List<Perro> ObtenerTodos();
        List<Perro> ObtenerMenores(int edad);
        void Crear(Perro perro);
    }
}
